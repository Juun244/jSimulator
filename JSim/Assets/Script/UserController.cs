using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public float speed;
    GameObject MainCamera;


    void Awake() 
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update() 
    {
        Control();
    }
    void FixedUpdate()
    {
         
    }
    
    void Control()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftMove();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightMove();
        }
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveCamera();
        }
        */
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
            Vector3 target = transform.position + new Vector3(-10, 0, 0);
            transform.position = Vector3.Slerp(transform.position, target, speed);
        }
    }

    public void RightMove()
    {
        if (transform.position.x < 5)
        {
            Vector3 target = transform.position + new Vector3(10, 0, 0);
            transform.position = Vector3.Slerp(transform.position, target, speed);
        }
    }

    public void MoveCamera()
    {
        if(MainCamera.GetComponent<Camera>().Setvalue == 0)
        {
            MainCamera.GetComponent<Camera>().Setvalue = 1;
        }
        else if(MainCamera.GetComponent<Camera>().Setvalue == 1)
        {
            MainCamera.GetComponent<Camera>().Setvalue = 2;
        }
        else if(MainCamera.GetComponent<Camera>().Setvalue == 2)
        {
            MainCamera.GetComponent<Camera>().Setvalue = 0;
        }
    }

}