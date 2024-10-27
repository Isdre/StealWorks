using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class StartCooking : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private bool canCook;
    private bool cooking;
    [SerializeField] private GameObject icon;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F) && canCook) {
            canvas.SetActive(true);
            Time.timeScale = 0f;
            cooking = true;
        } else if (cooking && Input.GetKeyDown(KeyCode.Escape)) {
            canvas.SetActive(false);
            Time.timeScale = 1f;
            cooking = false;
        }
    }

    public void StopCooking() {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        cooking = false;
    }
    
    public void SetIcon(bool active) {
        icon.SetActive(active);
    }
    
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.isTrigger) return;
        if (col.gameObject.CompareTag("Player")) {
            canCook = true;
            SetIcon(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.isTrigger) return;
        if (col.gameObject.CompareTag("Player")) {
            canCook = false;
            SetIcon(false);
        }
    }
}
