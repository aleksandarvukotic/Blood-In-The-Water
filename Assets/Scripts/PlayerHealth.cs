using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    public int currentHealth;
    float hungerDecreaseHealthFish = 20f;
    int maxHealth = 5;

    HungerMeter hungerMeter;
    void Start()
    {
        hungerMeter = GetComponent<HungerMeter>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthSlider.value = currentHealth;
    }

    public void HarpoonHealthDamage()
    {
        currentHealth--;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Health"))
        {
            currentHealth++;
            hungerMeter.currentHunger += hungerDecreaseHealthFish;
            Destroy(other.gameObject);
        }
    }
}
