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
            TTL--;
            Debug.Log("Child");
            KidMovement km = target.GetComponent<KidMovement>();
            km.canMove = false;
            km.Invoke("UnlockMove", stunTime);
            if (TTL == 0) Destroy(this.gameObject);
        }

        public override void OnKindergartenerEnter(GameObject target) {
            TTL--;
            TeacherMovement km = target.GetComponent<TeacherMovement>();
            km.canMove = false;
            km.Invoke("UnlockMove", stunTime);
            if (TTL == 0) Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D col) {
            
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Kid")) OnChildEnter(col.gameObject);
            if (col.gameObject.CompareTag("Kindergartener")) OnKindergartenerEnter(col.gameObject);
        }
    }
}