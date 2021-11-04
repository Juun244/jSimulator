using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    float rx;
    float ry;
    float xrotSpeed = 50;
    float yrotSpeed = 200;

    void FixedUpdate()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y"); 

        rx += xrotSpeed * my * Time.deltaTime;
        ry += yrotSpeed * mx * Time.deltaTime;

        
        rx = Mathf.Clamp(rx, -80, 80);
        transform.eulerAngles = new Vector3(-rx, ry, 0);
    }
}
