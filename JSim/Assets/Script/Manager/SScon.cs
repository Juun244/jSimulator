using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SScon : MonoBehaviour
{
    public GameObject GameManager;

    Button button; public void OnClickButton() 
    { 
        GameManager.GetComponent<GameManager>().state = 2;
    }
    
    void Start() 
    { 
        button = GetComponent<Button>(); button.onClick.AddListener(OnClickButton); 
    }
}
