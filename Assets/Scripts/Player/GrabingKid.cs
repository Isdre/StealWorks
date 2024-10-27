using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player {
    public class GrabingKid : MonoBehaviour
    {
        // Lista dzieci, które gracz może dodać do swojej kolekcji
        private List<GameObject> collectedKids = new List<GameObject>();

        // Maksymalna liczba miejsc na "Kid"
        private int maxKids = 2;
        public Image uiImageSlot1;
        public Image uiImageSlot2;
        public bool canGrab = false;
        public GameObject currentChild;
        public bool canRealeseChild = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("MeatGrinder"))
            {
                canRealeseChild = true;
               
            }
            
            if (other.isTrigger) return;
            if (other.CompareTag("Kid"))
            {
                canGrab = true;
                currentChild = other.gameObject;
            }
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("MeatGrinder"))
            {
                canRealeseChild = false;
            }
            
            if (other.isTrigger) return;
            if (other.CompareTag("Kid"))
            {
                canGrab = false;
                currentChild = null;
            }
            
        
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
                    Kid kidScript = currentChild.GetComponent<Kid>();
                    if (kidScript != null)
                    {
                        // Ustaw ikonę na odpowiednim slocie UI zależnie od liczby dzieci w liście
                        if (collectedKids.Count == 1)
                        {
                            uiImageSlot1.sprite = kidScript.icon;
                        }
                        else if (collectedKids.Count == 2)
                        {
                            uiImageSlot2.sprite = kidScript.icon;
                        }

                        // Wywołaj metodę Collect na Kid
                        kidScript.Collect();
                    }
                }
            }

            if (canRealeseChild)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    ReleaseKids();
                }
            }
        }

        public void ReleaseKids()
        {
            // Czyszczenie ikonek z UI
            uiImageSlot1.sprite = null;
            uiImageSlot2.sprite = null;

            // Opróżnia listę dzieci
            collectedKids.Clear();
        
            Debug.Log("Dzieci zostały opuszczone.");
        }
    }
}
