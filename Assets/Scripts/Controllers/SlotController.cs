using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Engine {

    public class SlotController : MonoBehaviour {

        [SerializeField] bool hasOrder = false;
        public bool HasOrder { get { return hasOrder; } }

        [SerializeField] bool readyForOrder = true;
        public bool ReadyForOrder { get { return readyForOrder; } }
        [SerializeField] float readyForOrderTimer = 0f;

        [SerializeField] Text orderText;
        [SerializeField] Task thisTask;
        [SerializeField] float taskTimer = 0;
        [SerializeField] Slider orderSlider;
        public Task ThisTask { get { return thisTask; } }

        [SerializeField] MissedTaskController missedTaskController;
                
        private void Awake() {
            orderText = GetComponentInChildren<Text>();
            orderSlider = GetComponentInChildren<Slider>();
            missedTaskController = FindObjectOfType<MissedTaskController>();
            orderSlider.gameObject.SetActive(false);
        }

        private void Update() {
            if (hasOrder) {
                taskTimer -= Time.deltaTime;
                UpdateSlider();
                if (taskTimer <= 0) {
                    FailTask();
                }
            } else if (readyForOrder == false) {
                if (readyForOrderTimer > 0) {
                    readyForOrderTimer -= Time.deltaTime;
                } else if (readyForOrderTimer <= 0) {
                    readyForOrder = true;
                }
            }
        }

        void FailTask() {
            thisTask = null;
            orderText.text = "[empty]";
            orderSlider.gameObject.SetActive(false);
            hasOrder = false;
            readyForOrderTimer = 5f;
            missedTaskController.AddMiss(1);
        }
        
        void UpdateSlider() {
            float percent = taskTimer / thisTask.taskTime;
            if (percent > 1) percent = 1;
            orderSlider.value = percent;
        }

        public void ReceiveOrder(Task newTask) {
            orderText.text = newTask.itemWanted.name;
            thisTask = newTask;
            hasOrder = true;
            readyForOrder = false;
            taskTimer = newTask.taskTime;
            orderSlider.gameObject.SetActive(true);
        }

        public void FillOrder(Item turnIn) {
            orderSlider.gameObject.SetActive(false);
            readyForOrderTimer = 5f;
            hasOrder = false;
            thisTask = null;
            orderText.text = "BLANK";
        }

    }

}