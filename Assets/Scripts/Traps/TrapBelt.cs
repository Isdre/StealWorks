using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Traps {
    [System.Serializable]
    public struct TrapPref {
        public string name;
        public Sprite icon;
        public GameObject prefab;
    }

public class TrapBelt : MonoBehaviour
{
    public List<TrapPref> trapDefs = new();
    public List<int> trapCount;
    public List<TrapSlot> slots = new();
    [SerializeField] private GameObject trapSlot;
    private int selectedTrap = 0;

    private void Awake() {
        foreach(TrapPref trapPref in trapDefs) {
            TrapSlot ts = Instantiate(trapSlot,transform).GetComponent<TrapSlot>();
            slots.Add(ts);
            ts.SetSprite(trapPref.icon);
            ts.SetAmount(0);
            trapCount.Add(0);
        }
    }
}
}