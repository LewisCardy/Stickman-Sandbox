using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxPlayerHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetPlayerHealth(float health){
        slider.value = health;
    }

    public float checkPlayerHealth(){
        return slider.value;
    }
}
