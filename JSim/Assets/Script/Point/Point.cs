using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    GameObject pManager;

    void Start()
    {
        pManager = GameObject.Find("Points");
    }

    void OnCollisionEnter(Collision colliderP)
    {
        pManager.GetComponent<CheckPointManager>().progress++;
        this.gameObject.SetActive(false);
    }
}
