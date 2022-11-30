using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;

    void Start(){
        startTime = Time.time;
    }
    void Update(){
        float t = Time.time - startTime;
        string minutes = ((int) t/60).ToString();
        string seconds = (t % 60).ToString("f1");
        timerText.text = minutes + ":" + seconds;

        

    }
}
