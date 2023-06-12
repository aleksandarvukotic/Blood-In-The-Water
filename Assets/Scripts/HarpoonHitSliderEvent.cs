using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarpoonHitSliderEvent : MonoBehaviour
{
    [SerializeField] Slider fightSlider;
    [SerializeField] float clickPoint = 3f;
    [SerializeField] float escapeTreshold = 50f;
    [SerializeField] float leakOfPoint = 5f;
    [SerializeField] float startOfEventFill = 25f;
    [SerializeField] float currentFill;
    [SerializeField] float harpoonHungerDamage = 5f;

    HungerMeter hungerMeter;
    PlayerHealth playerHealth;
    void Start()
    {
        hungerMeter = GetComponent<HungerMeter>();
        playerHealth = GetComponent<PlayerHealth>();
        fightSlider.gameObject.SetActive(false);
        currentFill = startOfEventFill;
    }

    void Update()
    {
        if (currentFill >= escapeTreshold)
        {
            fightSlider.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        SlideClickFight();
        ScoreDecay();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Harpoon"))
        {
            currentFill = startOfEventFill;
            fightSlider.gameObject.SetActive(true);

            hungerMeter.currentHunger -= harpoonHungerDamage;
            playerHealth.HarpoonHealthDamage();

            Destroy(other.gameObject);
            Time.timeScale = 0f;
        }
    }
    private void SlideClickFight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentFill += clickPoint;
        }
        fightSlider.value = currentFill;
    }
    private void ScoreDecay()
    {
        if (fightSlider.gameObject.activeInHierarchy)
        {
            currentFill -= leakOfPoint * Time.unscaledDeltaTime * 2f;
        }

        if (currentFill <= 0f)
        {
            fightSlider.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }


}
