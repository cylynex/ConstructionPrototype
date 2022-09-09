using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine;
using Tools;

namespace Items {
 
    public class WinnableItem : MonoBehaviour, IInteractable {

        LevelController levelController;

        void Start() {
            levelController = FindObjectOfType<LevelController>();
        }

        public void Use() {
            if (levelController.TurnInItem(GetComponent<ThisItem>().thisItem, this.gameObject)) {
                Clear();
            } else {
                print("No orders asking for this item currently.");
            } 
        }

        public void Clear() {
            GetComponent<ThisItem>().isUsed = false;
            transform.parent.GetComponent<IInteractable>().Clear();
            gameObject.SetActive(false);
        }

        public bool Send() { return true; }
               
    }

}
