using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuMusic : MonoBehaviour
{
    private void Update(){
        if (SceneManager.GetActiveScene().name == "Level White" || SceneManager.GetActiveScene().name == "Level Variation 1" || SceneManager.GetActiveScene().name == "Level Variation 2" || SceneManager.GetActiveScene().name == "Level Variation 3"){
            Debug.Log("hjoshndfisnipsnmfip[knmsdp[fm[smf");
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Awake(){
        GameObject[] music = GameObject.FindGameObjectsWithTag("Menu Music");
        if(music.Length > 1){
            Destroy(this.gameObject);
        }
        
            
    } 
}
