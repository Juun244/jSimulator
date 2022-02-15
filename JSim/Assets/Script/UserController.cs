using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public GameObject Road;
    bool state;
    

    void Awake() 
    {
        state = false;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = true;
            Road.SetActive(true);
        }
    }
    void FixedUpdate()
    {
         
    }
    
  

}