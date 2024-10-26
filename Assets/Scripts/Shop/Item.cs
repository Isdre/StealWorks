using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Shop{
    
    public class Item : MonoBehaviour {
        public string Name;
        [SerializeField] private TextMeshProUGUI textName;
        public int gold;
        [SerializeField] private TextMeshProUGUI textGold;
        [SerializeField] private Image image;

        public void SetParam(Sprite sprite) {
            textGold.text = gold.ToString();
            textName.text = Name;
            image.sprite = sprite;
        }

        public void BuyItem() {
            if (GameManager.Instance.TakeGold(gold))
                GameManager.Instance.AddItem(Name);
        }
    }
}