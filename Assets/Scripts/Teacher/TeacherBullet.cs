using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Player;

namespace Teacher {
    public class TeacherBullet : MonoBehaviour
    {
        public Vector3 Direction = Vector3.zero;
        public float Damage = 0f;
        private float timeToLife = 0.25f;
        [SerializeField] private float speed = 20f;
        private float timer;

        private void Start() {
            timer = timeToLife;
        }

        private void Update() {
            timer -= Time.deltaTime;
            transform.position += Time.deltaTime * speed * Direction;
            if (timer < 0f) Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.isTrigger) return;
            if (col.gameObject.CompareTag("Player")) {
                col.gameObject.GetComponent<Stats>().currentHealth -= Damage;
                Destroy(this.gameObject);
            }

            if (col.gameObject.CompareTag("Kid")) {
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}