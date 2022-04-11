using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    float currentHealth;
    public float maxHealth;

    public Slider slider;
    public static HealthBar Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }

    public float getHealth()
    {
        return slider.value;
    }



}
