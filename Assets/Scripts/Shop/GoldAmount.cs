using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Shop{
    public class GoldAmount : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private GameManager _manager;

        private void Start() {
            _manager = GameManager.Instance;
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            _text.text = _manager.GetGold().ToString();
        }
    }
}