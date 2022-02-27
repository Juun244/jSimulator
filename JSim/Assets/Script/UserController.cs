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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                LeftMove();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                RightMove();
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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if(other.gameObject.tag == "Item")
        {
            GameManager.instance.Score++;
            //audio.Play();
            other.gameObject.SetActive(false);
            GameManager.instance.ScoreCount(GameManager.instance.Score);
        }
    }

    public void LeftMove()
    {
        if(transform.position.x > -5)
        {
            Vector3 target = new Vector3(transform.position.x - 10f, transform.position.y, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, target, speed);
            curtime = cooltime;
        }
    }

    public void RightMove()
    {
        if (transform.position.x < 5)
        {
            Vector3 target = new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, target, speed);
            curtime = cooltime;
        }
    }

}