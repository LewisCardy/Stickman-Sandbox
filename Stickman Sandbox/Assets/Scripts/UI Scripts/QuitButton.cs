using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    //the quit button
    Button button;
    void Start(){
        button = GetComponent<Button>();
        button.onClick.AddListener(Exit);
    }

    //quits the application
    void Exit(){
        Application.Quit();
    }
    
}
