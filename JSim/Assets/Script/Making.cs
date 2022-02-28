using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Making : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject player;
    float timer = 0;
    float difficulty = 5;
    public float timeDiff;
    float set = 0;
    int random;
    public Transform SpawnPoint;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // DifficultySet();
        CreateObstacle();
    }

    void DifficultySet()
    {
        if (GameManager.instance.Score == 0)
        {
            timeDiff = 1;
            obstacle1.GetComponent<Move>().speed = 30;
            obstacle2.GetComponent<Move>().speed = 30;
        }
        else if (GameManager.instance.Score == 10)
        {
            timeDiff = 0.7f;
            obstacle1.GetComponent<Move>().speed = 50;
            obstacle2.GetComponent<Move>().speed = 50;
        }
        else if (GameManager.instance.Score == 20)
        {
            obstacle1.GetComponent<Move>().speed = 60;
            obstacle2.GetComponent<Move>().speed = 60;
        }
        else if (GameManager.instance.Score == 30)
        {
            timeDiff = 0.68f;
            obstacle1.GetComponent<Move>().speed = 65;
            obstacle2.GetComponent<Move>().speed = 65;
        }
        else if (GameManager.instance.Score == 40)
        {
            timeDiff = 0.65f;
            obstacle1.GetComponent<Move>().speed = 70;
            obstacle2.GetComponent<Move>().speed = 70;
        }
        else if (GameManager.instance.Score == 50)
        {
            timeDiff = 0.6f;
            obstacle1.GetComponent<Move>().speed = 75;
            obstacle2.GetComponent<Move>().speed = 75;
        }
        else if (GameManager.instance.Score == 70)
        {
            timeDiff = 0.58f;
            obstacle1.GetComponent<Move>().speed = 80;
            obstacle2.GetComponent<Move>().speed = 80;
        }
        else if (GameManager.instance.Score == 90)
        {
            timeDiff = 0.5f;
            obstacle1.GetComponent<Move>().speed = 90;
            obstacle2.GetComponent<Move>().speed = 90;
        }
        else if (GameManager.instance.Score == 100)
        {
            timeDiff = 0.5f;
            obstacle1.GetComponent<Move>().speed = 100;
            obstacle2.GetComponent<Move>().speed = 100;
        }
    }

    void CreateObstacle()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff && set == 0)
        {
            random = Random.Range(0, 2);
            GameObject newobstacle = Instantiate(obstacle1, SpawnPoint.position, SpawnPoint.rotation);
            if (random == 0)
            {
                newobstacle.transform.position = new Vector3(transform.position.x + 5, SpawnPoint.position.y, SpawnPoint.position.z);
                newobstacle.transform.rotation = Quaternion.Euler(0, 270, 0);
            }
            if (random == 1)
            {
                newobstacle.transform.position = new Vector3(transform.position.x - 5, SpawnPoint.position.y, SpawnPoint.position.z);
            }
            timer = 0;
            set = 1;
        }

        if (timer > timeDiff && set == 1)
        {
            Instantiate(obstacle2, SpawnPoint.position, SpawnPoint.rotation);
            timer = 0;
            set = 0;
        }
    }
}
