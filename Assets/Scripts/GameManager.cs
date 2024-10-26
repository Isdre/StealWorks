using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public struct ItemCount {
    public ItemCount(string n, int c) {
        name = n;
        count = c;
    }
    public string name;
    public int count;
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;
    public List<ItemCount> Inventory = new();
    [SerializeField] private int _gold = 0;


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(this.gameObject);
        }
    }

    public int GetGold() {return _gold;}

    public void AddGold(int gold) {
        _gold += gold;
    }

    public bool TakeGold(int howMuch) {
        if (_gold < howMuch) return false;
        _gold -= howMuch;
        return true;
    }

    public void AddItem(string item) {
        ItemCount i = Inventory.Where(x => x.name == item).FirstOrDefault();
        Debug.Log(i.name);
        Debug.Log(i.count);
        if (i.name != null) {
            Inventory.RemoveAll(x => x.name == item);
            i.count++;    
        }
        else i = new ItemCount(item,1);
        Inventory.Add(i);
    }

    public void RemoveItem(string item)
    {
        ItemCount i = Inventory.Where(x => x.name == item).FirstOrDefault();
        Inventory.RemoveAll(x => x.name == item);
        i.count--;
        Inventory.Add(i);
    }

    //<3
    public bool NegateBool(bool variable) {
        return !variable;
    }
}
