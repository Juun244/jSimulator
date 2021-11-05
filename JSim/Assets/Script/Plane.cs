using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void OnCollisionEnter(Collision colliderP)
    {
        gameManager.GetComponent<GameManager>().car.transform.position
            = gameManager.GetComponent<GameManager>().carT;

        gameManager.GetComponent<GameManager>().car.transform.rotation
            = Quaternion.Euler(0, 90, 0);
    }
}
