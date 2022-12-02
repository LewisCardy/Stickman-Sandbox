using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    //the enemy healthbar
    public Slider slider;

    //sets the max value of the healthbar
    public void SetMaxEnemyHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }

    //sets the current value of the healthbar
    public void SetEnemyHealth(float health){
        slider.value = health;
    }
}
