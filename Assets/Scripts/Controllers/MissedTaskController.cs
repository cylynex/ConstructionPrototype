using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Engine {

    public class MissedTaskController : MonoBehaviour {

        [SerializeField] int misses = 0;

        public void AddMiss(int amount) {
            misses += amount;
            GetComponent<Text>().text = misses.ToString();
        }

    }
}
