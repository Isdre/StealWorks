using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Shop{
    public class Item : MonoBehaviour {
        public string Name;
        [SerializeField] private TextMeshProUGUI textName;
        public int gold;
        [SerializeField] private TextMeshProUGUI textGold;

        private void Start() {
            textGold.text = gold.ToString();
            textName.text = Name;
        }

        public void BuyItem() {
            if (GameManager.Instance.TakeGold(gold))
                GameManager.Instance.AddItem(Name);
        }
    }
}