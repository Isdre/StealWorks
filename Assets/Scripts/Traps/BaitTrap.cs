using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kids;
using Teacher;

namespace Traps {
    public class BaitTrap : Trap
    {
        public int TTL = 1;
        public float stunTime = 3f;

        public override void OnChildEnter(GameObject target) {
            Debug.Log("Child");
            KidMovement km = target.GetComponent<KidMovement>();
            km.RunToTarget(transform.position);
        }

        public override void OnKindergartenerEnter(GameObject target) {

        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Kid")) {
                TTL--;
                if (TTL == 0) Destroy(this.gameObject); 
            }
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Kid")) OnChildEnter(col.gameObject);
        }
    }
}