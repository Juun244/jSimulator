using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadAnimation : MonoBehaviour
{
    public float speed;
    float cooltime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        cooltime += Time.deltaTime;
        
        if(cooltime>=32)
        {
            cooltime = 0;
        }
        
    }
}
