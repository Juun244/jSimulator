using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Making : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    float timer = 0;
    public float timeDiff;
    float set = 0;
    int random;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff && set == 0) 
        {
            random = Random.Range(0, 2);
            GameObject newobstacle = Instantiate(obstacle1);
            if (random == 1)
            {
                newobstacle.transform.position = new Vector3(-21,3.3f,11);
            }
            timer = 0;
            set = 1;
        }

        if (timer > timeDiff && set == 1)
        {
            Instantiate(obstacle2);
            timer = 0;
            set = 0;
        }
    }
}
