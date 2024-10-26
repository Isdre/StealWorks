using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Shop{
    public class Item : MonoBehaviour {
        public int itemId;
        public int gold;
        [SerializeField] private TextMeshProUGUI text;

        private void Start() {
            text.text = gold.ToString();
        }

        public void BuyItem() {

        }
    }
}