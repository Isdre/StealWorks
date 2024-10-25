using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour
{
    // Przypisujemy Sprite do ikony dziecka
    public Sprite icon;

    // Funkcja wywoływana, gdy gracz zbiera obiekt Kid
    public void Collect()
    {
        Debug.Log("Dziecko zebrane.");
        gameObject.SetActive(false);
    }
}
