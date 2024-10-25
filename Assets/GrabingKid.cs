using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class GrabingKid : MonoBehaviour
    {
        // Lista dzieci, które gracz może dodać do swojej kolekcji
        private List<GameObject> collectedKids = new List<GameObject>();

        // Maksymalna liczba miejsc na "Kid"
        private int maxKids = 2;
        public bool canGrab = false;
        public GameObject currentChild;

        private void OnTriggerEnter2D(Collider2D other)
        {
            canGrab = true;
            currentChild = other.gameObject;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            canGrab = false;
            currentChild = null;
        }

        private void Update()
        {
            if (canGrab)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0)  && collectedKids.Count < maxKids)
                {
                    // Dodaj obiekt do listy
                    collectedKids.Add(currentChild);

                    // Można dodać tutaj opcjonalny komunikat lub efekt wizualny
                    Debug.Log("Zebrano dziecko! Liczba zebranych: " + collectedKids.Count);

                    
                    // Opcjonalnie: wyłącz collider, aby uniknąć kolejnych wykryć lub ukryj obiekt
                    currentChild.gameObject.SetActive(false); // Wyłącza obiekt "Kid"
                    canGrab = false;
                    currentChild = null;
                }

            }
        }
    }
}
