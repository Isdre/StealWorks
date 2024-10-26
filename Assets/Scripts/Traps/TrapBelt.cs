using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

namespace Traps {
    [System.Serializable]
    public struct TrapPref {
        public string Name;
        public Sprite icon;
        public GameObject prefab;
    }

public class TrapBelt : MonoBehaviour
{
    public static TrapBelt Instance = null;
    public List<TrapPref> trapDefs = new();
    public List<int> trapCount;
    public List<TrapSlot> slots = new();
    [SerializeField] private GameObject trapSlot;
    private int selectedTrap = 0;

    private void Awake() {
        if (Instance == null) Instance = this;
        if (Instance != this) Destroy(this.gameObject);

        foreach(TrapPref trapPref in trapDefs) {
            TrapSlot ts = Instantiate(trapSlot,transform).GetComponent<TrapSlot>();
            slots.Add(ts);
            ts.SetSprite(trapPref.icon);
            ts.SetAmount(0);
            trapCount.Add(0);
        }
    }

    public void AddTrap(string n) {
        int target = trapDefs.FindIndex(x => x.Name == n);
        trapCount[target]++;
        slots[target].SetAmount(trapCount[target]);
    }
}
}