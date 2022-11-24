using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject underline;
    void Start(){
        underline = GameObject.Find("Underline");
    }
    
    void OnMouseOver(){
        underline.SetActive(true);
    }
}
