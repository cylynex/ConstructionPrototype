using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Engine {
 
    public class ActiveReset : MonoBehaviour {

        [SerializeField] List<GameObject> defaultInactives = new List<GameObject>();
        [SerializeField] GameObject defaultActive;

        private void OnEnable() {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(false);
            }

            defaultActive.SetActive(true);
        }

    }

}
