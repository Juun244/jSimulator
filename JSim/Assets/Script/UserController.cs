using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public float speed = 30;
    public float r_speed = 80;

    public bool gearState = true;
    

    void Awake() 
    {
        gearState = true;
    }

    void Update() 
    {
        Gear();

        Debug.Log(gearState);
    }
    void FixedUpdate()
    {
        Move();
        Handle();
    }

    void Move()
    {
        
        Vector3 _moveVertical0 = transform.forward * 1;
        Vector3 _moveVertical1 = transform.forward * -1;

        Vector3 _velocity0 = (_moveVertical0).normalized * speed;
        Vector3 _velocity1 = (_moveVertical1).normalized * speed;

        if(gearState == true && Input.GetKey("w"))
            this.gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + _velocity0 * Time.deltaTime);

        else if(gearState == false && Input.GetKey("w"))
            this.gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + _velocity1 * Time.deltaTime);
    }

    void Handle()
    {
        if(gearState == true)
        {
            if(Input.GetKey("a") && Input.GetKey("w"))
            this.transform.Rotate(Vector3.down, Time.deltaTime * r_speed);

        if (Input.GetKey("d") && Input.GetKey("w"))
            this.transform.Rotate(Vector3.up, Time.deltaTime * r_speed);
        }

        else if(gearState == false)
        {
            if (Input.GetKey("d") && Input.GetKey("w"))
            this.transform.Rotate(Vector3.down, Time.deltaTime * r_speed);

        if (Input.GetKey("a") && Input.GetKey("w"))
            this.transform.Rotate(Vector3.up, Time.deltaTime * r_speed);
        }
    }

    void Gear() // true = D false = R
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(gearState == true)
                gearState = false;

            else if(gearState ==false)
                gearState = true;
        }
    }
}