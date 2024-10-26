using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Traps {
public class TrapSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCount;
    [SerializeField] private Image image;
    private Image _image;

    private void Awake() {
        _image = GetComponent<Image>();
    }

    public void SetSprite(Sprite sprite) {
        image.sprite = sprite;
    }

    public void SetAmount(int count) {
        textCount.text = count.ToString();
    }

    public void IsSelected(bool selected) {
        if (selected) _image.color = new Color32(255,0,0,255);
        else _image.color = new Color32(84,84,84,25);
    }
}
}