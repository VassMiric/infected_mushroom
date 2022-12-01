using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider slider;
    public Health playHealth;
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    void Update() 
    {
        SetHealth(playHealth.HealthPoints);
    }

    
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
