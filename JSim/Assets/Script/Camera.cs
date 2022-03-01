using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject player;
    public Vector3 Offset1;
    public Vector3 Offset2;
    public Vector3 Offset3;
    public int Setvalue = 0;

    void Awake()
    {
        CameraSet();
    }
    void Update()
    {
        //CameraSet();
    }

    public void CameraSet()
    {
        if (Setvalue == 0)
        {
            transform.position = player.transform.position + Offset1;
            transform.rotation = Quaternion.Euler(20, 0, 0);
        }
        else if(Setvalue == 1)
        {
            transform.position = player.transform.position + Offset2;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(Setvalue == 2)
        {
            transform.position = player.transform.position + Offset3;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
