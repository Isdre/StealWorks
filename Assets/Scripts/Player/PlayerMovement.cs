using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float runSpeed = 10f;
        [SerializeField] public float stamina = 100f;
        [SerializeField] public float maxStamina = 100f;
        [SerializeField] private float staminaDrainRate = 10f; // Ilość staminy zużywana na sekundę podczas biegu
        [SerializeField] private float staminaRegenRate = 5f; // Ilość staminy regenerowana na sekundę

        private Transform _transform;
        private bool isRunning = false;

        private void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f).normalized;

            // Sprawdzamy czy gracz trzyma spację i czy ma wystarczająco dużo staminy na bieg
            if (Input.GetKey(KeyCode.Space) && stamina > 0f)
            {
                isRunning = true;
                stamina -= staminaDrainRate * Time.deltaTime; // Zużycie staminy
            }
            
            {
                isRunning = false;

            }

            if (isRunning!)
            {
                // Regeneracja staminy, jeśli nie biegamy
                if (stamina < maxStamina)
                {
                    stamina += staminaRegenRate * Time.deltaTime;
                    stamina = Mathf.Clamp(stamina, 0, maxStamina); // Zapewniamy, że stamina nie przekroczy maxStamina

                }
            }

            // Ustaw prędkość zależnie od tego, czy gracz biegnie
                float currentSpeed = isRunning ? runSpeed : walkSpeed;
                _transform.position += direction * currentSpeed * Time.deltaTime;
            
        }
    }
}