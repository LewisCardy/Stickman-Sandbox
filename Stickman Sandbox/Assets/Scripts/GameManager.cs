using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

//Game manager script for handling many options throughout each scene including menu operations
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public TextMeshProUGUI scoreText;
    public Player player; 
    public GameObject pauseScreen; 

    public TMP_Dropdown resolutionDropdown; 

    public AudioMixer audioMixer;
    private float startTime;
    private bool paused = false;
    Resolution[] resolutions;
    public int score;


    void Start(){
        SetResolutionOptions(); 
        startTime = Time.time; 
        Unpause();
        pauseScreen.SetActive(false);
    }
    void Update(){
        //if pressed esc open pause menu
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (paused == true){
                Unpause();
                pauseScreen.SetActive(false);
            } else { //else if menu is alredy open close
                Pause();
                pauseScreen.SetActive(true);
                paused = true;
            }
        }
        if (paused == false){
            pauseScreen.SetActive(false);
        }
        Timer();
    }
    //the ingame UI timer
    public void Timer(){
        float t = Time.time - startTime; //start time of the game
        //split the time into m and s
        string minutes = ((int) t/60).ToString();
        string seconds = (t % 60).ToString("f1");

        timerText.text = minutes + ":" + seconds;//update the text with the new values
    }

    public void RestartGame(){ //restart the game after a certain time
        StartCoroutine(RestartScene());
        Unpause();
    }

    public void EndGame(){

    }

    public void PlayerDeath(){ //when player dies stop time and timer
        timerText.text = timerText.text;
        Pause();
    }

    //unpause the game
    public void Unpause(){
        paused = false;
        Time.timeScale = 1;
    }

    //restart the scene after a delay
    IEnumerator RestartScene(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //loads the same scene
        
    }

    //the score of the game and at the top of the UI
    public void Score(){
        score ++;
        scoreText.text = score.ToString();
    }

    //loads the scene with the name given
    public void LoadScene(string sceneName){
        Scene newScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    //pauses the game
    public void Pause(){
        Time.timeScale = 0;
    }

    //changes the volume of the game from the slider
    public void SetVolume(float volume){
        audioMixer.SetFloat("Volume", volume);
    }

    //changes the graphics quality from the dropdown
    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //makes the game fullscreen
    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    //sets the resolution options when the game starts and auto selects the user default
    public void SetResolutionOptions(){
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //changes the resolution of the game
    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
