using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Teacher {
    public class TeacherMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private Transform _player;
        private Transform _transform;
        private Rigidbody2D _rigid;

        public bool canMove = true;
        public bool run;
        private System.Random _rand;
        private Vector3 _direction;
        private float timeD = 3f;
        private float timerD;

        private void Start() {
            timerD = timeD;
            _player = GameObject.FindWithTag("Player").transform;
            _transform = transform;
            _rigid = GetComponent<Rigidbody2D>();
            _rand = new System.Random();
        }

        private void Update() {
            if (canMove) {
                if (run) _direction = (_player.position - _transform.position);
                timerD -= Time.deltaTime;
                if (timerD < 0f) {
                    _direction = new Vector3((float)_rand.NextDouble(),(float)_rand.NextDouble(),0f);
                    timerD = timeD;
                }
                _rigid.velocity = speed * Time.deltaTime * _direction.normalized;
            } 
        }

        public void UnlockMove() {canMove = true;}

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) {
                run = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) {
                run = false;
                _direction = new Vector3((float)_rand.NextDouble(),(float)_rand.NextDouble(),0f);
            }
        }
    }
}