using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop{
    public class Computer : MonoBehaviour {
        [SerializeField] GameObject icon;
        [SerializeField] GameObject shop;
        private bool _iconIs = false;

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

        public void BuyItem(int itemId, int gold) {
            
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) SetIcon(true);
        }

        private void OnTriggerExit2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) SetIcon(false);
        }
    }
}