using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tools;
using UnityEngine.SceneManagement;

namespace Engine {

    public class LevelController : MonoBehaviour {

        [SerializeField] Level level;
        [SerializeField] Project project;

        [SerializeField] List<GameObject> slots = new List<GameObject>();
        [SerializeField] List<Task> tasks = new List<Task>();

        [SerializeField] SuccessfulTicketCounter successfulTicketCounter;
        [SerializeField] TimerController timerController;

        WinCondition winCondition;

        [SerializeField] GameObject winPanel, losePanel;

        [SerializeField] GameController gameController;
        
        private void Awake() {

            gameController = FindObjectOfType<GameController>();
            project = gameController.GetProject;
            level = project.levels[gameController.GetLevelID];

            Time.timeScale = 1;

            // TODO - this doesnt really need to reread into a list - it can just work from the object. Fix later.
            foreach(Task thisTask in level.tasks) {
                tasks.Add(thisTask);
            }

        }

        private void Start() {
            successfulTicketCounter = FindObjectOfType<SuccessfulTicketCounter>();
            timerController = FindObjectOfType<TimerController>();
            IssueOrders();

            // Setup Win Conditions
            winCondition = level.winCondition;

            // Timer
            if (winCondition.timer > 0) timerController.SetupTimer(winCondition.timer);
            else timerController.SetBlank();

            // Number of Successful Tickets
            if (winCondition.numberTickets > 0) {
                successfulTicketCounter.SetNeededTickets(winCondition.numberTickets);
            }

        }

        private void Update() {
            IssueOrders();
        }

        public bool TurnInItem(Item itemToFinish, GameObject supplier) {
            for (int s = 0; s < slots.Count; s++) {
                if ((slots[s].GetComponent<SlotController>().HasOrder) && (itemToFinish != null)) {
                    Item thisSlotsItem = slots[s].GetComponent<SlotController>().ThisTask.itemWanted;
                    if (thisSlotsItem == itemToFinish) {
                        slots[s].GetComponent<SlotController>().FillOrder(itemToFinish);
                        successfulTicketCounter.AddTicket(1); // TODO score should be dynamically calculated
                        itemToFinish = null;
                        return true;
                    }
                }
            }
            return false;
        }

        void IssueOrders() {
            for (int i = 0; i < slots.Count; i++) {
                if (slots[i].GetComponent<SlotController>().ReadyForOrder) {
                    Task randTask = tasks[Random.Range(0, tasks.Count)];
                    slots[i].GetComponent<SlotController>().ReceiveOrder(tasks[Random.Range(0, tasks.Count)]);
                }
            }
        }

        public void Win() {
            Time.timeScale = 0;
            winPanel.SetActive(true);
            gameController.UnlockNextLevel();
        }

        public void Lose() {
            Time.timeScale = 0;
            losePanel.SetActive(true);
        }

        public void ReloadLevel() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void LoadMap() { // TODO - This is being used on a win.  Should also reload the project window for this project.
            SceneManager.LoadScene("Map");
        }


    }
}
