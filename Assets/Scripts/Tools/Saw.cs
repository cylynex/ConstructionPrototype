using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Engine;

namespace Tools {

    public class Saw : Tool, IReceiver, IInteractable {
                        
        [Header("Config")]
        [SerializeField] Item currentItem;

        [Header("Visuals")]
        [SerializeField] bool sawOn = false;
        [SerializeField] GameObject sawBlade;
        [SerializeField] GameObject uncutPineBoard;
        [SerializeField] GameObject cutPineBoard;
        Animator animator;

        private void Start() {
            animator = GetComponent<Animator>();
        }

        private void Update() {
            InnerUpdate();
            if (sawOn) {
                sawBlade.transform.Rotate(new Vector3(0, 300, 0) * Time.deltaTime);
            }
        }

        public bool Receive(Item receivedItem, int amount, GameObject sender) {
            if ((currentItem == null) && (!IsBusy)) {
                currentItem = receivedItem;
                uncutPineBoard.SetActive(true);
                UseTool(currentItem);
                TurnOnSaw();
                return true;
            } else {
                print("occupied");
                return false;
            }
        }

        public void Use() {
            
        }

        public bool Send() { return true; }

        public void Clear() {
            cutPineBoard.SetActive(false);
            currentItem = null;
            InnerClear();
        }
        

        void TurnOnSaw() {
            sawOn = true;
            animator.Play("CutWood");                      
        }

        void SwapBoardGraphic() {
            uncutPineBoard.SetActive(false);
            cutPineBoard.SetActive(true);
        }

        void TurnOffSaw() {
            sawOn = false;
        }

    }

}