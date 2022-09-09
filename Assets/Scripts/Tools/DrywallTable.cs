using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Tools {

    public class DrywallTable : Tool, IReceiver, IInteractable {

        Storage storage;
        [SerializeField] Item currentItem;
        [SerializeField] int quantity;
        [SerializeField] GameObject wholeDrywallSheet;
        [SerializeField] GameObject cutDrywallSheet1, cutDrywallSheet2;

        [SerializeField] public List<GameObject> itemsOnTable = new List<GameObject>();

        private void Start() {
            storage = GetComponent<Storage>();
        }

        void Update() {
            InnerUpdate();
            if (isFinished) {
                print("Done Cutting - change the graphics and clickables.");
                wholeDrywallSheet.SetActive(false);
                cutDrywallSheet1.SetActive(true);
                cutDrywallSheet2.SetActive(true);
                itemsOnTable.Add(cutDrywallSheet1);
                itemsOnTable.Add(cutDrywallSheet2);
                quantity = 2;
                isFinished = false;
            }
        }

        public bool Receive(Item receivedItem, int amount, GameObject sender) {

            if (currentItem == null) {
                currentItem = receivedItem;
                wholeDrywallSheet.SetActive(true);
                Use();
                return true;
            } else {
                print("occupied");
                return false;
            }
        }

        public bool Send() {
            return GetComponent<Storage>().StorageSend();
        }

        public void Clear() {
            quantity--;
            if (quantity == 0) {
                currentItem = null;
                InnerClear();
            }
        }

        public void Use() {
            UseTool(currentItem);
        }

        public void AddModifier() {

        }

    }

}
