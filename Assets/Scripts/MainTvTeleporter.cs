using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTvTeleporter : MonoBehaviour
{
    // Drugi obiekt MainTv, do którego gracz zostanie przeteleportowany
    public Transform otherTv;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawdza, czy obiekt, który wszedł w trigger, jest graczem
        if (other.CompareTag("Player"))
        {
            // Teleportacja gracza do pozycji drugiego telewizora
            other.transform.position = otherTv.position;
            Debug.Log("Gracz przeteleportowany do drugiego telewizora.");
        }
    }
}