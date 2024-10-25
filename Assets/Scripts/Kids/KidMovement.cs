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

        private void Start() {
            _player = GameObject.FindWithTag("Player").transform;
            _transform = transform;
            _rigid = GetComponent<Rigidbody2D>();
        }

        public void UnlockMove() {canMove = true;}

        private void Update() {
            if (canMove & run) {
                Vector3 direction = (_transform.position - _player.position).normalized;
                _rigid.velocity = speed * Time.deltaTime * direction;
            } else _rigid.velocity = Vector3.zero;
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