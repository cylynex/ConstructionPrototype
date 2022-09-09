using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Tools {

    public class WoodRack : MonoBehaviour, IReceiver, IInteractable {
        
        Storage storage;
        
        private void Start() {
            storage = GetComponent<Storage>();
        }
        
        public bool Receive(Item receivedItem, int amount, GameObject sender) {
            if (storage.Receive(receivedItem, amount)) {
                return true;
            }
            return false;
        }        

        public bool Send() {
            return GetComponent<Storage>().StorageSend();
        }

        public void Clear() { }
        public void Use() { }

    }

}
