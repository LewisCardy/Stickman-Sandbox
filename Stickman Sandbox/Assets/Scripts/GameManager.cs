using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public Player player;
    private float startTime;

    public int score;

    void Start(){
        startTime = Time.time;
        Time.timeScale = 1;
    }
    void Update(){
        Timer();

    }
    public void Timer(){
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
        Time.timeScale = 0;
    }

    public void Unpause(){
        Time.timeScale = 1;
    }
    IEnumerator RestartScene(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Score(){
        score ++;
        scoreText.text = score.ToString();
    }

    public void LoadScene(string sceneName){
        Scene oldScene = SceneManager.GetActiveScene();
        Scene newScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.LoadScene(sceneName);
    }
    // public void LoadOptionsMenu(string sceneName){
        
    // }
    // public void LoadLevelSelectMenu(string sceneName){
        
    // }
    // public void LoadSceneDefault(string sceneName){
        
    // }
    // public void LoadSceneVariation1(string sceneName){
        
    // }
    // public void LoadSceneVariation2(string sceneName){
        
    // }
    // public void LoadSceneVariation3(string sceneName){
        
    // }

}
