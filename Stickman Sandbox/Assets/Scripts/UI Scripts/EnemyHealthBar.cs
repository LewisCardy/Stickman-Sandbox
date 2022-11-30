using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxEnemyHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }
    // Start is called before the first frame update
    public void SetEnemyHealth(float health){
        slider.value = health;
    }
}
