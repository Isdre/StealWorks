using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps {
    public abstract class Trap : MonoBehaviour
    {
        public int TTL = 1;

        public virtual void OnChildEnter(GameObject target) {
            TTL--;
            Debug.Log("Kid");
            if (TTL == 0) Destroy(this.gameObject);
        }

        public virtual void OnKindergartenerEnter(GameObject target) {
            TTL--;
            Debug.Log("Kindergartener");
            if (TTL == 0) Destroy(this.gameObject);
        }
    }
}