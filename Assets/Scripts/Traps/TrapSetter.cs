using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps {

    [System.Serializable]
    public struct TrapCount {
        public TrapCount(GameObject n, int c) {
            trap = n;
            count = c;
        }

        public GameObject trap;
        public int count;
    }

    public class TrapSetter : MonoBehaviour
    {
        [SerializeField] private int activeId;
    }
}