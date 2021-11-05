using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject car;
    public Vector3 carT;


    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject Canvas3;


    public Text NameText;

    private static GameManager instance = null;

    int state = 1;

    ///////////////////////////////////////////////////////////////

    private struct Record
    {
        public string name;
        public float _time;
    }

    private List<Record> Records = new List<Record>();

    private void AddRecord()    //주행중 정보로 리스트 추가
    {
        Record addRecord = new Record();

        addRecord._time = float.Parse(this.gameObject.GetComponent<UiManager>().text_Timer.text);
        addRecord.name = this.gameObject.GetComponent<UiManager>().text_Name.text;

        Records.Add(addRecord);
        SortList();
        PrintRanking();
    }

    private void SortList() //리스트 전체 시간순으로 정렬
    {
        for (int i = 0; i < Records.Count; i++)
        {
            for (int j = i + 1; j < Records.Count; j++)
            {
                if (Records[j]._time < Records[i]._time)
                {
                    Record tmp = Records[i];
                    Records[i] = Records[j];
                    Records[j] = tmp;
                }
            }
        }
    }

    public Text n1;
    public Text t1;

    public Text n2;
    public Text t2;

    public Text n3;
    public Text t3;

    public Text n4;
    public Text t4;

    public Text n5;
    public Text t5;

    private void PrintRanking() //정렬후 상위5등까지
    {
        n1.text = Records[0].name;
        t1.text = Records[0]._time.ToString();

        n2.text = Records[1].name;
        t2.text = Records[1]._time.ToString();

        n3.text = Records[2].name;
        t3.text = Records[2]._time.ToString();

        n4.text = Records[3].name;
        t4.text = Records[3]._time.ToString();

        n5.text = Records[4].name;
        t5.text = Records[4]._time.ToString();
    }




    void Awake()
    {
        carT = car.transform.position;

        Records = new List<Record>
            {
            new Record {name = "AAA",_time = 999},
            new Record {name = "AAA",_time = 999},
            new Record {name = "AAA",_time = 999},
            new Record {name = "AAA",_time = 999},
            new Record {name = "AAA",_time = 999}
                };


        PrintRanking();
    }






    void Update()
    {
        P_Manage();
    }

    void P_Manage()
    {
        if(state == 0)  //랭킹 출력
        {
            Time.timeScale = 0;

            Canvas1.SetActive(false);
            Canvas2.SetActive(false);
            Canvas3.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
                state = 1;  //주행
        }

        else if(state == 1) //이름 입력
        {
            Time.timeScale = 0;

            Canvas1.SetActive(false);
            Canvas2.SetActive(true);
            Canvas3.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Return))
                state = 2;  //주행
                
        }

        else if (state == 2) //주행
        {
            Time.timeScale = 1;

            Canvas1.SetActive(true);
            Canvas2.SetActive(false);
            Canvas3.SetActive(false);

            if (this.gameObject.GetComponent<CheckPointManager>().progress == 1)    //채크포인트 도달시
            {
                AddRecord();
                state = 0;  //랭킹 출력

                car.transform.position = carT;
                this.gameObject.GetComponent<CheckPointManager>().progress = 0;
                this.gameObject.GetComponent<UiManager>().time = 0;
                NameText.text = null;
            }
        }
    }
}
