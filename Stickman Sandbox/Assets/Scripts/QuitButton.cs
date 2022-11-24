using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    Button button;
    void Start(){
        button = GetComponent<Button>();
        button.onClick.AddListener(Exit);
    }

    void Exit(){
        Application.Quit();
    }
    
}
