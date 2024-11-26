using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private void Awake() => instance = this;

    public float currentHealth, maxHealth;

    public Slider healtSlider;

    void Start()
    {
        currentHealth = maxHealth;

        healtSlider.maxValue = maxHealth;
        healtSlider.value = currentHealth;
    }

    private void Update()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if (currentHealth <= 0) 
        {
            gameObject.SetActive(false);
        }

        healtSlider.value = currentHealth;
    }
}
