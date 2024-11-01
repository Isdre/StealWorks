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
        private Animator _animator;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

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
                if (Input.GetKeyDown(KeyCode.F)  && collectedKids.Count < maxKids)
                {
                 
                    collectedKids.Add(currentChild);
                    Kid kidScript = currentChild.GetComponent<Kid>();
                    if (kidScript != null)
                    {
                        if (collectedKids.Count == 1)
                        {
                            uiImageSlot1.sprite = kidScript.icon;
                            _animator.SetBool("LeftKid",true);
                        }
                        else if (collectedKids.Count == 2)
                        {
                            _animator.SetBool("RightKid",true);
                            uiImageSlot2.sprite = kidScript.icon;
                        }
                        
                        kidScript.Collect();
                    }
                }
            }

            if (canRealeseChild && collectedKids.Count>0)
            {
                if (Input.GetKeyDown(KeyCode.F))
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
            _animator.SetBool("RightKid",false);
            _animator.SetBool("LeftKid",false);
            
            childCount=collectedKids.Count;
            // Opróżnia listę dzieci
            collectedKids.Clear();
        
            Debug.Log("Dzieci zostały opuszczone.");
        }
    }
}
