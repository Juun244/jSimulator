using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    GameObject DeadLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        DeadLine = GameObject.FindGameObjectWithTag("DeadLine");
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeadLine")
        {
            Destroy(gameObject);
        }
    }

}
