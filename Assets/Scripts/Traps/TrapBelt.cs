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
    public List<int> trapCount = new();
    public List<TrapSlot> slots = new();
    [SerializeField] private GameObject trapSlot;

    private void Awake() {
        if (Instance == null) Instance = this;
        if (Instance != this) Destroy(this.gameObject);

        int i = 0;
        
        foreach(TrapPref trapPref in trapDefs) {
            TrapSlot ts = Instantiate(trapSlot,transform).GetComponent<TrapSlot>();
            slots.Add(ts);
            ts.SetSprite(trapPref.icon);
            ts.SetAmount(trapCount[i]);
            i++;
        }
    }

    public void AddTrap(string n) {
        int target = trapDefs.FindIndex(x => x.Name == n);
        trapCount[target]++;
        slots[target].SetAmount(trapCount[target]);
    }
}
}