using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private void Start() {
            _player = GameObject.FindWithTag("Player").transform;
            _transform = transform;
            _rigid = GetComponent<Rigidbody2D>();
        }

        public void UnlockMove() {canMove = true;}

        private void Update() {
            Vector3 direction = Vector3.zero;
            if (canMove) {
                if (run) {
                    direction = (_transform.position - _player.position).normalized;
                } else if (runToTarget) {
                    direction = (_target - _transform.position).normalized;
                }
            }

            _rigid.velocity = speed * Time.deltaTime * direction;
        }

        public void RunToTarget(Vector3 target) {
            _target = target;
            runToTarget = true;
        }

        public void StopRunToTarget() {
            runToTarget = false;
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) {
                run = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) {
                run = false;
            }
        }
    }
}