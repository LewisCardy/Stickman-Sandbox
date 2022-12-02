using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    //player healthbar
    public Slider slider;

    //sets the max value of the healthbar
    public void SetMaxPlayerHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }
    //sets the current value of the healthbar
    public void SetPlayerHealth(float health){
        slider.value = health;
    }
}
