using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerMeter : MonoBehaviour
{
    float maxHunger = 100f;
    [HideInInspector] public float currentHunger;
    [HideInInspector] public float foodIncrease = 8f;
    float hungerIncreaseRate = 0.2f;

    public Slider hungerSlider;

    private void Start()
    {
        currentHunger = Random.Range(50f, 100f);
        StartCoroutine("Hunger");
    }

    private void Update()
    {
        if(currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }

        hungerSlider.value = currentHunger;
    }
    public void FoodEaten()
    {
        currentHunger += foodIncrease;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            FoodEaten();
            Destroy(other.gameObject);
        }
    }

    public IEnumerator Hunger()
    {
        while (true)
        {
            currentHunger--;

            yield return new WaitForSeconds(hungerIncreaseRate);
        }
    }
}
