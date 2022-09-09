using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Tools {

    public class Modifier : MonoBehaviour, IInteractable {

        [SerializeField] GameObject tool;
        [SerializeField] int modID;

        private void Start() {
            tool = transform.parent.gameObject;
        }

        public void Use() {
            IModifiable[] possibleModTargets = tool.GetComponentsInChildren<IModifiable>();
            foreach (IModifiable target in possibleModTargets) {
                if (target.AddMod(modID)) return;
            }

        }

        public void Clear() { }
        public bool Send() { return true; }

    }

}