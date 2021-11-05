using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
  
    //name
    public Text text_Name;

    //check point
    public GameObject Point;
    public Text text_Point;

    //time
    public Text text_Timer;
    public float time;


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
            this.gameObject.GetComponent<CheckPointManager>().progress.ToString() + "/ 5";
    }


    void Name()
    {
        text_Name.text = this.gameObject.GetComponent<GameManager>().NameText.text;
    }

}
