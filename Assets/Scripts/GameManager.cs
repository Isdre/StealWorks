using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance = null;
    private int _gold = 0;


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

    //<3
    public bool NegateBool(bool variable) {
        return !variable;
    }
}
