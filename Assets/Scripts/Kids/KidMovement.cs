using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Kids {
    public class KidMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private Transform _player;
        private Transform _transform;
        private Rigidbody2D _rigid;

        public bool canMove = true;
        [SerializeField] private bool run;
        [SerializeField] private bool runToTarget;
        private Vector3 _target;
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

        public void UnlockMove() {canMove = true;}
        public void LockMove() {
            Debug.Log("LockMove");
            canMove = false;
            _rigid.velocity = Vector3.zero;
        }


        private void Update() {
            if (canMove) {
                if (run) {
                    _direction = (_transform.position - _player.position);
                } else if (runToTarget) {
                    _direction = (_target - _transform.position);
                }

                timerD -= Time.deltaTime;
                if (timerD < 0f) {
                    _direction = new Vector3((float)_rand.NextDouble(),(float)_rand.NextDouble(),0f);
                    timerD = timeD;
                }

                _rigid.velocity = speed * Time.deltaTime * _direction.normalized;
            }
        }

        public void RunToTarget(Vector3 target) {
            _target = target;
            runToTarget = true;
        }

        public void StopRunToTarget() {
            runToTarget = false;
            _direction = new Vector3((float)_rand.NextDouble(),(float)_rand.NextDouble(),0f);
        }

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