using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Engine {

    public class TimerController : MonoBehaviour {

        [SerializeField] Text timerDisplay;
        [SerializeField] float timer;
        [SerializeField] bool timerRunning = false;
        LevelController levelController;

        private void Awake() {
            levelController = FindObjectOfType<LevelController>();
            timerDisplay = GetComponent<Text>();
            // TEMP
            timer = 30f;
            timerDisplay.text = timer.ToString("N0");
        }

        private void Update() {
            if (timerRunning) {
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    timer = 0;
                    timerDisplay.text = timer.ToString("N0");
                    levelController.Lose();
                }
                timerDisplay.text = timer.ToString("N0");
            }
        }

        public void SetupTimer(float timerValue) {
            print("Theres a timer, set it up");
            timer = timerValue;
            timerRunning = true;
        }
               
        public void SetBlank() {
            timerDisplay.text = "Untimed Level";
        }

    }

}
