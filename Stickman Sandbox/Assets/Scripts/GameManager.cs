using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;

    void Start(){
        startTime = Time.time;
        Time.timeScale = 1;
    }
    void Update(){
        float t = Time.time - startTime;
        string minutes = ((int) t/60).ToString();
        string seconds = (t % 60).ToString("f1");
        timerText.text = minutes + ":" + seconds;

    }

    public void RestartGame(){
        Time.timeScale = 1;
        StartCoroutine(RestartScene());
    }

    public void EndGame(){

    }

    public void PlayerDeath(){
        timerText.text = timerText.text;
        //Time.timeScale = 0;
    }

    public void Unpause(){
        Time.timeScale = 1;
    }
    IEnumerator RestartScene(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
