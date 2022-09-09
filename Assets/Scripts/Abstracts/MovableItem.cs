using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
 
    public class MovableItem : MonoBehaviour, IInteractable {

        [SerializeField] Item thisItem;        
        [SerializeField] int yield = 1;
        [SerializeField] GameObject receiver;
        [SerializeField] GameObject parent;

        void Start() {
            thisItem = GetComponent<ThisItem>().thisItem;
            if (!GetComponent<ThisItem>().isEnabled) GetComponent<BoxCollider>().enabled = false;
        }

        public void Use() {
            if (receiver.GetComponent<IReceiver>().Receive(GetComponent<ThisItem>().thisItem, yield, this.gameObject)) {
                print("successful offload");
                Clear();
            }
        }

        public void Clear() {
            if (parent != null) parent.GetComponent<IInteractable>().Clear();
        }

        public bool Send() { return true; }

    }

}
