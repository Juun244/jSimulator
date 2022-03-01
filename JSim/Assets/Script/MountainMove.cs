using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainMove : MonoBehaviour
{
    public float scrollSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;// + (Vector3.back * Time.deltaTime * scrollSpeed);
        newPosition.z = Mathf.Repeat(-Time.time * scrollSpeed, 494f);
        transform.position = newPosition;
    }
}
