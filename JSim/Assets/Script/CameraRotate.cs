using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    public GameObject player;
    public Vector3 Offset;


    void Awake()
    {
        transform.Rotate(0, 90, 0);
    }
    void Update()
    {
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + Offset;
    }

}
