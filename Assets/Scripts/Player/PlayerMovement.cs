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
        public bool isRunning = false;
        private Animator _animator;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _transform = transform;
        }

        private void Update()
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f).normalized;

            _animator.SetFloat("Front", Input.GetAxis("Vertical") * -1f);
            
            // Sprawdzamy czy gracz trzyma spację i czy ma wystarczająco dużo staminy na bieg
            if (Input.GetKey(KeyCode.Space) && stamina > 0f) {
                isRunning = true;
                stamina -= staminaDrainRate * Time.deltaTime; // Zużycie staminy
            }
            else {
               isRunning = false;
            }

            if (isRunning==false)
            {
             staminaDrain();
               
            }

            // Ustaw prędkość zależnie od tego, czy gracz biegnie
                float currentSpeed = isRunning ? runSpeed : walkSpeed;
                _transform.position += direction * currentSpeed * Time.deltaTime;
            
        }


        void staminaDrain()
        {
            if (stamina < maxStamina)
            { 
                Debug.Log("Stamina: "+stamina+"MaxStamina: "+maxStamina);
                stamina += staminaRegenRate*Time.deltaTime;


            }
        }
    }
}