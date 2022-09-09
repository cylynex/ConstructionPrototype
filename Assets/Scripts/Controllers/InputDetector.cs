using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using Items;

namespace Engine {

    public class InputDetector : MonoBehaviour {
               
        private void Update() {
            if (Input.GetMouseButtonDown(0)) { // TODO: THIS NEEDS TO CHANGE TO TOUCH FOR MOBILE BUILD
                CastRay();
            }
        }

        void CastRay() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                print("HIT: " + hit.transform.gameObject.name);
                hit.transform.gameObject.GetComponent<IInteractable>().Use();
            }
        }

    }

}