using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreentryTransformList;


    private void Awake()
    {
        entryContainer = GameObject.Find("recordContainer").transform;
        entryTemplate = GameObject.Find("recordTemplate").transform;

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{score = 325 , name = "QWF"},
            new HighscoreEntry{score = 521 , name = "HTR"},
            new HighscoreEntry{score = 1.6f , name = "GF"},
            new HighscoreEntry{score = 1.5f , name = "q2er"},
            new HighscoreEntry{score = 165 , name = "qeg"},
        };

        //sort
        for(int i = 0; i < highscoreEntryList.Count; i++)
        {
            for(int j = i +1; j < highscoreEntryList.Count ; j++)
            {
                if(highscoreEntryList[j].score < highscoreEntryList[i].score )
                {
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreentryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreentryTransformList);
        }


        Highscores hiscores = new Highscores { highscoreentryList = highscoreEntryList };
        string json = JsonUtility.ToJson(hiscores);
        PlayerPrefs.SetString("rankTable",json);
        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetString("rankTable"));
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 10f;


        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;

        switch (rank)
        {
            default:
                rankString = rank + "th"; break;

            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }

        entryTransform.Find("NoText").GetComponent<Text>().text = rankString;

        float score = highscoreEntry.score;

        entryTransform.Find("RecordText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    private class Highscores
    { 
        public List<HighscoreEntry> highscoreentryList;
    }


    [System.Serializable]
    private class HighscoreEntry
    {
        public float score;
        public string name;
    }
}
