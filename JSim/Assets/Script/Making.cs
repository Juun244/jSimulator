using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Making : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject player;
    float timer = 0;
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
        CreateObstacle();
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
