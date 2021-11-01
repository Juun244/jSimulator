using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUi : MonoBehaviour
{
    public Text text_Timer;
    public float limit;

    public float time;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        double _time = (int)time;

        time += Time.deltaTime;
        text_Timer.text = _time.ToString();
    }
}
