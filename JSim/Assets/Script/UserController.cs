using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public float cooltime;
    private float curtime;
    public float speed;


    void Awake() 
    {

    }

    void Update() 
    {
        Move();
    }
    void FixedUpdate()
    {
         
    }
    
    void Move()
    {
        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow)&&transform.position.x>-5)
            {
                Vector3 target = new Vector3(transform.position.x-10f, transform.position.y, transform.position.z);
                transform.position = Vector3.Slerp(transform.position, target , speed);
                curtime = cooltime;
            }
            if (Input.GetKey(KeyCode.RightArrow)&&transform.position.x<5)
            {
                Vector3 target = new Vector3(transform.position.x+10f, transform.position.y, transform.position.z);
                transform.position = Vector3.Slerp(transform.position, target, speed);
                curtime = cooltime;
            }
        }
        curtime -= Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
        if(other.gameObject.tag == "Obstacle")
        {
            GameManager.instance.Restart();
        }
    }


}