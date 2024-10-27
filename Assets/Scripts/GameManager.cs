using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Traps;
using UnityEngine.SceneManagement;

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
        var existingItem = Inventory.FirstOrDefault(x => x.name == item);

        if (existingItem.name == item) {
            // Item found, so increase the count
            int index = Inventory.IndexOf(existingItem);
            existingItem.count++;
            Inventory[index] = existingItem;
        }
        TrapBelt.Instance.AddTrap(item);
    }

    public void RemoveItem(string item)
    {
        ItemCount i = Inventory.Where(x => x.name == item).FirstOrDefault();
        int index = Inventory.IndexOf(i);
        i.count--;
        Inventory[index] = i;
    }

    public void RestartGame() {
        SceneManager.LoadScene(1);
    }
    
    //<3
    public bool NegateBool(bool variable) {
        return !variable;
    }
}
