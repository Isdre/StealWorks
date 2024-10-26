using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop{
public class KeyIcon : MonoBehaviour
{
    [SerializeField] private Transform target;
    private RectTransform _canvas;
    private RectTransform _rekt;

    private void Start() {
        _rekt = GetComponent<RectTransform>();
        _canvas = transform.parent.GetComponent<RectTransform>();
    }

    private void Update() {
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(target.position + new Vector3(0f,2f,0f));
        Vector2 finalPosition = new Vector2(viewportPosition.x * _canvas.sizeDelta.x, viewportPosition.y * _canvas.sizeDelta.y);
        _rekt.position = finalPosition;
    }
}
}