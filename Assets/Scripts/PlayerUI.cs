using UnityEngine;
using UnityEngine.UI;

namespace Player {
public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider staminaSlider;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Stats playerStats;

    private void Start()
    { 
        staminaSlider.maxValue = playerMovement.maxStamina;
        healthSlider.maxValue= playerStats.maxHealth;
      
    }

    private void Update()
    {
        if (playerMovement != null)
        {
            // Aktualizujemy wartości sliderów na podstawie aktualnego stanu gracza
            healthSlider.value = playerStats.currentHealth;
            staminaSlider.value = playerMovement.stamina;
        }
    }
}   
}