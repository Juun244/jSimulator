using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void OnCollisionEnter(Collision colliderP)
    {
        gameManager.GetComponent<CheckPointManager>().progress++;
        this.gameObject.SetActive(false);
    }
}
