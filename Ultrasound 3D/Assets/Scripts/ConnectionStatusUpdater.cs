using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeUiText : MonoBehaviour
{
    // UI Text GameObjects
    public GameObject textmeshpro_connectionStatus;
    // maybe an FPS or Mb/s display?

    // Game Variables
    public string connectionStatus;
    //public double number;

    //[SerializeField] GameObject CS;

    // Text Components
    TextMeshPro textmeshpro_connectionStatus_text;
    

    void Start()
    {
        // Text Mesh Pro
        textmeshpro_connectionStatus_text = gameObject.GetComponent<TextMeshPro>();
        textmeshpro_connectionStatus_text.text = " hello";
      

    }

    void Update()
    {
        // Text Mesh Pro
        //textmeshpro_connectionStatus_text.text = connectionStatus;
       
    }
    public void changeText()
    {
        textmeshpro_connectionStatus_text.text = "World";
    }
}