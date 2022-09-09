using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Engine {

    public class SuccessfulTicketCounter : MonoBehaviour {

        [SerializeField] int tickets = 0;
        public int TicketsFinished { get { return tickets; } }
        [SerializeField] int numberTicketsNeeded; // 0 for unused
        Text ticketCounter;
        LevelController levelController;

        private void Awake() {
            levelController = FindObjectOfType<LevelController>();
            ticketCounter = GetComponent<Text>();
        }

        public void SetNeededTickets(int amount) {
            numberTicketsNeeded = amount;
            SetTicketCounter();
        }

        public void AddTicket(int amount) {
            tickets += amount;
            SetTicketCounter();
            if (tickets >= numberTicketsNeeded) levelController.Win();
        }

        void SetTicketCounter() {
            if (numberTicketsNeeded > 0) ticketCounter.text = tickets.ToString() + " / " + numberTicketsNeeded.ToString();
            else ticketCounter.text = tickets.ToString();
        }

    }
}
