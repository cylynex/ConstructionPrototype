using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Tools {

    public class Storage : MonoBehaviour {
        
        [SerializeField] public GameObject[] storedItem;
        
        public bool Receive(Item incomingItem, int amount) {

            // See if there is a slot free
            for (int i = 0; i < storedItem.Length; i++) {
                //if (storedItem[i].GetComponent<ThisItem>().thisItem == null) {
                if (!storedItem[i].GetComponent<ThisItem>().isUsed) { 
                    storedItem[i].GetComponent<ThisItem>().thisItem = incomingItem;
                    storedItem[i].GetComponent<ThisItem>().isUsed = true;
                    UpdateGraphic();
                    return true;
                }
            }
            print("ALL SLOTS FULL - CANNOT RECEIVE");
            return false;
        }        

        public bool StorageSend() { // DEPRECATED - Keeping in for reference for now
            print("storage ready to send");
            for (int i = 0; i < storedItem.Length; i++) {
                print("sending item out");
                if (storedItem[i].GetComponent<ThisItem>().isUsed) {
                    storedItem[i].GetComponent<ThisItem>().isUsed = false;
                    storedItem[i].GetComponent<ThisItem>().thisItem = null;
                    storedItem[i].SetActive(false);
                    UpdateGraphic();
                    return true;
                } 
            }
            return false;
        }

        public void UpdateGraphic() {
            for (int i = 0; i < storedItem.Length; i++) {
                if (storedItem[i].GetComponent<ThisItem>().isUsed) {
                    storedItem[i].SetActive(true);
                } else {
                    storedItem[i].SetActive(false);
                }
            }
        }
    }

}
