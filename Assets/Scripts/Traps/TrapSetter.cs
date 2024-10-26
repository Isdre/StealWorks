using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps {
    public class TrapSetter : MonoBehaviour {
        private TrapBelt belt;
        [SerializeField] private int activeId;
        private int beltWidth;

        public void Start() {
            belt = TrapBelt.Instance;
            beltWidth = belt.trapDefs.Count;
            belt.slots[activeId].IsSelected(true);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) changeSelected(-1); 
            if (Input.GetKeyDown(KeyCode.E)) changeSelected(1);
            if (Input.GetKeyDown(KeyCode.R)) SetTrap();
        }

        private void SetTrap() {
            if (belt.trapCount[activeId] <= 0) return;
            belt.trapCount[activeId]--;
            belt.slots[activeId].SetAmount(belt.trapCount[activeId]);
            Instantiate(belt.trapDefs[activeId].prefab,transform.position, Quaternion.identity);
        }

        private void changeSelected(int change) {
            belt.slots[activeId].IsSelected(false);
            activeId += change;
            if (activeId == beltWidth) activeId = 0;
            if (activeId == -1) activeId = beltWidth - 1;
            belt.slots[activeId].IsSelected(true);
        }
    }
}