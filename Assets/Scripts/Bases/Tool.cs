using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;

namespace Tools {
 
    public class Tool : MonoBehaviour {

        [Header("Tool Config")]
        [SerializeField] float baseUseTime;

        [Header("Timers")]
        [SerializeField] float timer = 0f;
        [SerializeField] Slider timeSlider;

        [Header("Informational")]
        [SerializeField] bool isBusy = false;
        public bool IsBusy { get { return isBusy; } }
        [SerializeField] bool isWorking = false;
        public bool IsWorking { get { return isWorking; } }
        public bool isFinished = false;
        
        [SerializeField] Item baseItem;
        [SerializeField] protected Item itemOnDeck;
        
        protected void InnerUpdate() {
            if (isWorking) {
                timer += Time.deltaTime;
                UpdateSlider();
                if (timer >= baseUseTime) {
                    timer = 0;
                    isWorking = false;
                    itemOnDeck = baseItem.whenUsed;
                    timeSlider.value = 0;
                    timeSlider.gameObject.SetActive(false);
                    baseItem = null;
                    isFinished = true;
                }
            }
        }

        protected void UseTool(Item itemToUse) {
            if (!isBusy) {
                print("using tool with: " + itemToUse);
                baseItem = itemToUse;
                isBusy = true;
                isWorking = true;
                timer = 0;
                timeSlider.gameObject.SetActive(true);
            } else {
                print("TOOL IS BUSY");
            }
        }

        void UpdateSlider() {
            float percent = timer / baseUseTime;
            if (percent > 1) percent = 1;
            timeSlider.value = percent;
        }

        public void InnerClear() {
            itemOnDeck = null;
            baseItem = null;
            isBusy = false;
        }

    }

}
