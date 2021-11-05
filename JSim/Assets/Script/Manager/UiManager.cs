using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    /*
    private static UiManager instance = null;

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
    */



    public Text text_Timer;
    public float time;
    //////////////////////////
    public GameObject Point;
    public Text text_Point;
    //////////////////////////
    public Text text_Name;


    void Update()
    {
        Name();
        Timer();
        CheckPoint();
    }

    void Timer()
    {
        time += Time.deltaTime;
        text_Timer.text = time.ToString("F2");
    }

    void CheckPoint()
    {
        text_Point.text =
            Point.GetComponent<CheckPointManager>().progress.ToString() + "/ 5";
    }


    void Name()
    {
        text_Name.text = "Name";
    }

}
