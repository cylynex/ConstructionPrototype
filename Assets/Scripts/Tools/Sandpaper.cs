using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Engine;

namespace Tools {

    public class Sandpaper : Tool, IInteractable {

        [Header("Config")]
        [SerializeField] Item itemToUse;
        [SerializeField] GameObject woodRack;

        [Header("Visuals")]
        [SerializeField] bool sanderOn = false;
        [SerializeField] GameObject board;
        Animator animator;

        private void Start() {
            animator = GetComponent<Animator>();
        }

        private void Update() {
            InnerUpdate();
        }

        public void Use() {
            if (!IsBusy) {
                print("Sandpaper");
                if (woodRack.GetComponent<IInteractable>().Send()) {
                    board.SetActive(true);
                    UseTool(itemToUse);
                } else {
                    print("COULDN'T LOCATE ANY WOOD");
                }
            }
        }

        public void Clear() {
            board.SetActive(false);
            InnerClear();
        }

        public bool Send() { return true; }


        // Animation Stuff 
        void TurnOnSaw() {
            sanderOn = true;
            animator.Play("CutWood");
        }
        
        void TurnOffSaw() {
            sanderOn = false;
        }

    }

}