using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps {
    public abstract class Trap : MonoBehaviour
    {
        public virtual void OnChildEnter(GameObject target) {
            Debug.Log("Kid");
        }

        public virtual void OnKindergartenerEnter(GameObject target) {
            Debug.Log("Kindergartener");
        }
    }
}