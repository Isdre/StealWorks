using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Shop{
    public class Item : MonoBehaviour {
        public string name;
        [SerializeField] private TextMeshProUGUI textName;
        public int gold;
        [SerializeField] private TextMeshProUGUI textGold;

        private void Start() {
            textGold.text = gold.ToString();
            textName.text = name;
        }

        public void BuyItem() {

        }
    }
}