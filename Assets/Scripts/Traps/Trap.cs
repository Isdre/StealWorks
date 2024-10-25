using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps {
    public abstract class Trap : MonoBehaviour
    {
        public int TTL = 1;

        public virtual void OnChildEnter(GameObject target) {
            TTL--;
            Debug.Log("Child");
            if (TTL == 0) Destroy(this.gameObject);
        }

        public virtual void OnKindergartenerEnter(GameObject target) {
            TTL--;
            Debug.Log("Kindergartener");
            if (TTL == 0) Destroy(this.gameObject);
        }


        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Child")) OnChildEnter(col.gameObject);
            if (col.gameObject.CompareTag("Kindergartener")) OnKindergartenerEnter(col.gameObject);
        }
    }
}