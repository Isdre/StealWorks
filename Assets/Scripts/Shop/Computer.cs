using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shop{
    [System.Serializable]
    public struct ItemDef {
        public string name; 
        public Sprite sprite;
        public int gold;
    }

    public class Computer : MonoBehaviour {
        public List<ItemDef> itemsDef = new();
        [SerializeField] private GameObject itemSlotPrefab;
        [SerializeField] private Transform container;
        [SerializeField] private GameObject icon;
        [SerializeField] private GameObject shop;
        private bool _iconIs = false;

        private void Start() {
            foreach(ItemDef i in itemsDef) {
                Item item = Instantiate(itemSlotPrefab,container).GetComponent<Item>();
                item.gold = i.gold;
                item.Name = i.name;
                item.SetParam(i.sprite);
            }
        }

        private void Update() {
            if (_iconIs && Input.GetKeyDown(KeyCode.F)) SetShop(true); 
        }

        public void SetIcon(bool active) {
            icon.SetActive(active);
            _iconIs = active;
        }

        public void SetShop(bool active) {
            shop.SetActive(active);
            if (active) Time.timeScale = 0f;
            else Time.timeScale = 1f;
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) SetIcon(true);
        }

        private void OnTriggerExit2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) SetIcon(false);
        }
    }
}