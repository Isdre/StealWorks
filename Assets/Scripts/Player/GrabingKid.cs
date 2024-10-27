using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player {
    public class GrabingKid : MonoBehaviour
    {
        
        private List<GameObject> collectedKids = new List<GameObject>();

        
        private int maxKids = 2;
        
        public Image uiImageSlot1;
        public Image uiImageSlot2;
        public bool canGrab = false;
        public GameObject currentChild;
        public bool canRealeseChild = false;
        public int childCount = 0;
        public MeatGrinder grinder;
        
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Kid"))
            {
                canGrab = true;
                currentChild = other.gameObject;
            }
            if (other.CompareTag("MeatGrinder"))
            {
               canRealeseChild = true;
               
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Kid"))
            {
                canGrab = false;
                currentChild = null;
            }
            if (other.CompareTag("MeatGrinder"))
            {
              canRealeseChild = false;
            }
        
        }

        private void Update()
        {
            if (canGrab)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0)  && collectedKids.Count < maxKids)
                {
                 
                    collectedKids.Add(currentChild);
                    Kid kidScript = currentChild.GetComponent<Kid>();
                    if (kidScript != null)
                    {
                        if (collectedKids.Count == 1)
                        {
                            uiImageSlot1.sprite = kidScript.icon;
                        }
                        else if (collectedKids.Count == 2)
                        {
                            uiImageSlot2.sprite = kidScript.icon;
                        }
                        
                        kidScript.Collect();
                    }
                }
            }

            if (canRealeseChild)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    ReleaseKids();
                    grinder.Grind();
                    
                }
            }
        }

        public void ReleaseKids()
        {
            // Czyszczenie ikonek z UI
            uiImageSlot1.sprite = null;
            uiImageSlot2.sprite = null;
            
            childCount=collectedKids.Count;
            // Opróżnia listę dzieci
            collectedKids.Clear();
        
            Debug.Log("Dzieci zostały opuszczone.");
        }
    }
}
