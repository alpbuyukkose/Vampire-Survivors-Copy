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

    public GameObject deathEffect;

    void Start()
    {
        maxHealth = PlayerStatController.instance.health[0].value;

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

            Instantiate(deathEffect, transform.position, transform.rotation);

            LevelManager.instance.EndLevel();

            SFXManager.instance.PlaySFX(3);
        }

        healtSlider.value = currentHealth;
    }
}
