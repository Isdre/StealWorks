using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kids;
using Teacher;

namespace Traps {
    public class TaxTrap : Trap
    {
        public int TTL = 4;

        public override void OnKindergartenerEnter(GameObject target) {
            Destroy(target);
            TTL--;
            if (TTL == 0) Destroy(this.gameObject); 
        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Kindergartener")) OnKindergartenerEnter(col.gameObject);
        }
    }
}