using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuMusic : MonoBehaviour
{
    //the menu music for the game carrying ovfer the object on scene change
    private void Update(){
        //if its not a menu delete the menu music
        if (SceneManager.GetActiveScene().name == "Level White" || SceneManager.GetActiveScene().name == "Level Variation 1" || SceneManager.GetActiveScene().name == "Level Variation 2" || SceneManager.GetActiveScene().name == "Level Variation 3"){
            Destroy(this.gameObject);
        } else {
            //dont destroy on menu
            DontDestroyOnLoad(this.gameObject);
        }
    }
    //destroy the menu music 
    private void Awake(){
        GameObject[] music = GameObject.FindGameObjectsWithTag("Menu Music");
        if(music.Length > 1){
            Destroy(this.gameObject);
        }
        
            
    } 
}
