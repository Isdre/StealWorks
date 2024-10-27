using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTvTeleporter : MonoBehaviour
{
    // Drugi obiekt MainTv, do którego gracz zostanie przeteleportowany
    public Transform otherTv;
    public bool canTep = true;
    private MainTvTeleporter tv;

    private void Start()
    {
        tv = otherTv.GetComponent<MainTvTeleporter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawdza, czy obiekt, który wszedł w trigger, jest graczem
        if (other.CompareTag("Player"))
        {
            if (!canTep) return;
            tv.canTep = false;
            // Teleportacja gracza do pozycji drugiego telewizora
            other.transform.position = otherTv.position + new Vector3(0f,-1f,0f);
            Debug.Log("Gracz przeteleportowany do drugiego telewizora.");
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        // Sprawdza, czy obiekt, który wszedł w trigger, jest graczem
        if (other.CompareTag("Player"))
        {
            canTep = true;
        }
    }
}