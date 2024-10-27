using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profit : MonoBehaviour
{
    public float speed = 5f; // Prędkość poruszania się w górę (jednostki na sekundę)

    void Update()
    {
        // Poruszamy obiekt w górę w osi y z zadaną prędkością
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
