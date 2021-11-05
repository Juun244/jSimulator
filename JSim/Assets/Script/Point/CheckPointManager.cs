using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public GameObject point0;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;

    public int progress;

    void Start()
    {
        progress = 0;
    }

    
    void Update()
    {
        PointSerial();

        Debug.Log(progress);
    }

    void PointSerial()
    {
        if (progress == 1)
            point1.SetActive(true);

        else if (progress == 2)
            point2.SetActive(true);

        else if (progress == 3)
            point3.SetActive(true);

        else if (progress == 4)
        {
            point4.SetActive(true);
        }
            
    }
}
