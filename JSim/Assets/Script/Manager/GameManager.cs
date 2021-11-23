using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

using System.IO;
using System.Runtime.Serialization; 
using System.Runtime.Serialization.Formatters.Binary;




public class GameManager : MonoBehaviour
{
    public GameObject car;
    public Vector3 carT;

    public GameObject Canvas0; //main
    public GameObject Canvas1;//rank
    public GameObject Canvas2;//id input
    public GameObject Canvas3;//main ui
    public GameObject Canvas4;//last record

    public InputField lname;
    public Text NameText;


    public Text rName;
    public Text rRecord;

    public int state = 0;

    ///////////////////////////////////////////////////////////////


    [Serializable]
    public class Record
    {
        public string name;
        public float _time;
    }

    private List<Record> Records = new List<Record>
            {
            new Record {name = "No_Data",_time = 1000},
            new Record {name = "No_Data",_time = 1000},
            new Record {name = "No_Data",_time = 1000},
            new Record {name = "No_Data",_time = 1000},
            new Record {name = "No_Data",_time = 1000}
                };

    void SaveRecord() 
    {
        var binaryFormatter     = new BinaryFormatter();
        var memoryStream        = new MemoryStream();

        //Records trans byte arr    and save
        binaryFormatter.Serialize(memoryStream, Records);

        // 문자열 값으로 변환, 'Rank' string key값으로 PlayerPrefs에 저장.
        PlayerPrefs.SetString("Rank", Convert.ToBase64String(memoryStream.GetBuffer()));
    }



    private void AddRecord()    //랭킹 추가.
    {
        Record addRecord = new Record();

        addRecord._time = float.Parse(this.gameObject.GetComponent<UiManager>().text_Timer.text);
        addRecord.name = this.gameObject.GetComponent<UiManager>().text_Name.text;

        Records.Add(addRecord);
        SortList();
        PrintRanking();
    }

    private void SortList() //리스트 정렬
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

    private void PrintRanking()
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
        isCol = false;

        var data = PlayerPrefs.GetString("Rank");

        if(!string.IsNullOrEmpty(data))
        {
            var binaryFormatter = new BinaryFormatter();
            var memoryStream    = new MemoryStream(Convert.FromBase64String(data));

            //가져온 데이터를 바이트 배열로 변환
            //사용하기 위해 다시 리스트로 캐스팅.
            Records             = (List<Record>)binaryFormatter.Deserialize(memoryStream);
        }


        carT = car.transform.position;

        SortList();
        PrintRanking();
    }






    void Update()
    {
        P_Manage();
    }


    public bool isCol = false;

    void P_Manage()
    {
        if(state == 0)              //랭킹
        {
            Time.timeScale = 0;

            Canvas0.SetActive(true);
            Canvas1.SetActive(false);
            Canvas2.SetActive(false);
            Canvas3.SetActive(false);
            Canvas4.SetActive(false);

            
            if (Input.GetKeyDown(KeyCode.Return))
                state = 1; 

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        if(state == 1)              //랭킹
        {
            Time.timeScale = 0;

            Canvas0.SetActive(false);
            Canvas1.SetActive(false);
            Canvas2.SetActive(false);
            Canvas3.SetActive(true);
            Canvas4.SetActive(false);


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = 0;
            }


            if (Input.GetKeyDown(KeyCode.Return))
                state = 2; 
        }

        else if(state == 2)         //이름 입력
        {
            Time.timeScale = 0;

            Canvas0.SetActive(false);
            Canvas1.SetActive(false);
            Canvas2.SetActive(true);
            Canvas3.SetActive(false);
            Canvas4.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = 0;
            }

            if (Input.GetKeyDown(KeyCode.Return) && lname.text != "")
                state = 3;  
                
        }

        else if (state == 3)        //주행
        {
            Time.timeScale = 1;

            Canvas0.SetActive(false);
            Canvas1.SetActive(true);
            Canvas2.SetActive(false);
            Canvas3.SetActive(false);
            Canvas4.SetActive(false);
            car.GetComponent<UserController>().gearState = true;

            if (this.gameObject.GetComponent<CheckPointManager>().progress == 5)    //다 통과
            {
                state = 4;      //last record
            }

            
            if(this.gameObject.GetComponent<UiManager>().time > 180)
            {
                state = 0;

                car.transform.position = carT;
                car.transform.rotation = Quaternion.Euler(0, 90, 0);
                this.gameObject.GetComponent<CheckPointManager>().progress = 0;
                this.gameObject.GetComponent<UiManager>().time = 0;
                lname.text = "";
                NameText.text = "";
            }

            if( isCol == true )
            {
                state = 0;

                car.transform.position = carT;
                car.transform.rotation = Quaternion.Euler(0, 90, 0);
                this.gameObject.GetComponent<CheckPointManager>().progress = 0;
                this.gameObject.GetComponent<UiManager>().time = 0;
                lname.text = "";
                NameText.text = "";

                isCol = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                car.transform.position = carT;
                car.transform.rotation = Quaternion.Euler(0, 90, 0);
                this.gameObject.GetComponent<CheckPointManager>().progress = 0;
                this.gameObject.GetComponent<UiManager>().time = 0;
                lname.text = "";
                NameText.text = "";

                state = 0;
            }

            
        }


        else if(state == 4)         //last record
        {
            Time.timeScale = 0;

            Canvas0.SetActive(false);
            Canvas1.SetActive(false);
            Canvas2.SetActive(false);
            Canvas3.SetActive(false);
            Canvas4.SetActive(true);

            rName.text = NameText.text;
            rRecord.text = this.gameObject.GetComponent<UiManager>().time.ToString("N2");

            if (Input.GetKeyDown(KeyCode.Return))
            {
                AddRecord();
                SaveRecord();

                state = 1;  //rank

                car.transform.position = carT;
                car.transform.rotation = Quaternion.Euler(0, 90, 0);
                this.gameObject.GetComponent<CheckPointManager>().progress = 0;
                this.gameObject.GetComponent<UiManager>().time = 0;
                lname.text = "";
                NameText.text = "";
            }
        }
    }
}
