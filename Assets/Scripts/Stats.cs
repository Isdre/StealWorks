using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

namespace Player
{
    public class Stats : MonoBehaviour
    {
        public float maxHealth = 100f;
        private float h = 100f;

        public float currentHealth {
            get {
                return h;
            }
            
            set {
                h = value;
                _particleSystem.Play();
            }
        }

        private ParticleSystem _particleSystem;
        
        private void Awake() {
            _particleSystem = transform.GetChild(0).GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            if (currentHealth <= 0f) GameManager.Instance.RestartGame();
        }
    }

}
