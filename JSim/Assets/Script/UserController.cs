using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public float speed = 15;
    public float r_speed = 80;
 
    void FixedUpdate()
    {
        Move();
        Handle();
    }

    void Move()
    {
        float _moveDirZ = Input.GetAxisRaw("Vertical");
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveVertical).normalized * speed;

        this.gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    void Handle()
    {
        if(Input.GetKey("a") && Input.GetKey("w"))
            this.transform.Rotate(Vector3.down, Time.deltaTime * r_speed);

        if (Input.GetKey("d") && Input.GetKey("s"))
            this.transform.Rotate(Vector3.down, Time.deltaTime * r_speed);


        if (Input.GetKey("d") && Input.GetKey("w"))
            this.transform.Rotate(Vector3.up, Time.deltaTime * r_speed);

        if (Input.GetKey("a") && Input.GetKey("s"))
            this.transform.Rotate(Vector3.up, Time.deltaTime * r_speed);
    }
}