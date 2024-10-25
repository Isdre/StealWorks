using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kids;
using Teacher;

namespace Traps {
    public class StunTrap : Trap
    {
        public int TTL = 1;

        public override void OnChildEnter(GameObject target) {
            TTL--;
            Debug.Log("Child");
            target.GetComponent<KidMovement>().canMove = false;
            if (TTL == 0) Destroy(this.gameObject);
        }

        public void OnKindergartenerEnter(GameObject target) {
            TTL--;
            target.GetComponent<TeacherMovement>().canMove = false;
            if (TTL == 0) Destroy(this.gameObject);
        }


        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Kid")) OnChildEnter(col.gameObject);
            if (col.gameObject.CompareTag("Kindergartener")) OnKindergartenerEnter(col.gameObject);
        }
    }
}