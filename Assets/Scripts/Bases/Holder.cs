using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Engine;

namespace Tools {

    public class Holder : MonoBehaviour {

        [SerializeField] protected Item item;
        [SerializeField] Text whatsHere;
        [SerializeField] Button completeButton;
        [SerializeField] LevelController levelController;        

        private void Awake() {
            levelController = FindObjectOfType<LevelController>();

            /*
            completeButton = GetComponentInChildren<Button>();
            Text[] textareas = GetComponentsInChildren<Text>();

            completeButton.gameObject.SetActive(false);
            whatsHere = textareas[1];
            */
        }

        public bool ReceiveItem(Item newItem, GameObject sender) {
            if (item == null) {
                print("table receiving an item (from saw): " + sender.name);
                SetWhatsHere(newItem);
                return true;
            } else {
                print("TABLE CANNOT RECEIVE ALREADY HAS ITEM");
                return false;
            }
        }

        protected void SetWhatsHere(Item newItem) {
            item = newItem;
            whatsHere.text = newItem.itemName;
            completeButton.gameObject.SetActive(true);
            completeButton.onClick.RemoveAllListeners();
            completeButton.onClick.AddListener(() => levelController.TurnInItem(newItem, this.gameObject));
        }

        public void ConsumeProduct() {
            item = null;
            completeButton.gameObject.SetActive(false);
            whatsHere.text = "EMPTY";
        }

        

    }

}