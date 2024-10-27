using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfItem : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public string name;   // Nazwa przedmiotu
        public Sprite sprite; // Obrazek przedmiotu
    }

    public List<Item> items = new List<Item>(17); // Lista na 17 przedmiotów

 
   
}
