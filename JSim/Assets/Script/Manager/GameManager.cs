using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

    ///////////////////////////////////////////////////////////////

    public struct Record
    {
        public string name;
        public string time;
        public float _time;
    }

    public static List<Record> Records = new List<Record>();
    

    void Update()
    {
        //체크포인트 끝나면 Recording 호출.
    }


    private void Recording()
    {
        Record addRecord = new Record();

        //addRecord.name = 
        addRecord.time = this.gameObject.GetComponent<UiManager>().text_Timer.text;

        Records.Add(addRecord);
    }

    void SceneManage()
    {
        if (Input.GetKey("e"))
        {
            SceneManager.LoadScene("Ranking Scene");
        }
    }

    /*
    record manager 
     press anykey (driving scene)


    game manager
    check point (ranking scene)
     */
}
