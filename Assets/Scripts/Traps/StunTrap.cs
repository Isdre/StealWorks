using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kids;
using Teacher;

namespace Traps {
    public class StunTrap : Trap
    {
        public int TTL = 4;
        public float stunTime = 3f;

        public override void OnChildEnter(GameObject target) {
            TTL--;
            KidMovement km = target.GetComponent<KidMovement>();
            km.LockMove();
            km.Invoke("UnlockMove", stunTime);
            if (TTL == 0) Destroy(this.gameObject);
        }

        public override void OnKindergartenerEnter(GameObject target) {
            TTL--;
            TeacherMovement km = target.GetComponent<TeacherMovement>();
            km.LockMove();
            km.Invoke("UnlockMove", stunTime);
            if (TTL == 0) Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.isTrigger) return;
            if (col.gameObject.CompareTag("Kid")) OnChildEnter(col.gameObject);
            if (col.gameObject.CompareTag("Kindergartener")) OnKindergartenerEnter(col.gameObject);
        }
    }
}