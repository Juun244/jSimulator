using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IoManager : MonoBehaviour
{
    public static List<Record> Records = new List<Record>();
    string fullpth = "Asset/Record.Record.json";

    public GameObject GetInfo;  //record time

    public struct Record
    {
        public string name;
        public string time;
        public float _time;
    }


    private void Recording()
    {
        Record addRecord = new Record();

        //addRecord.name = 
        addRecord.time = GetInfo.GetComponent<UiManager>().text_Timer.text;

        Records.Add(addRecord);
    }
}
