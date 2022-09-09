using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {

    public class ModifiableItem : MonoBehaviour, IModifiable {

        [SerializeField] public bool mod1, mod2, mod3;
        [SerializeField] GameObject baseG, mod1G, mod2G, mod12G;

        void OnEnable() {
            mod1 = false;
            mod2 = false;
            mod3 = false;
            ResetGraphics();
        }

        public bool AddMod(int modID) {
            baseG.SetActive(false);
            switch (modID) {
                case 1: if (!mod1) { mod1 = true; UpdateGraphic(); return true; } else return false;
                case 2: if (!mod2) { mod2 = true; UpdateGraphic(); return true; } else return false;
                default: return false;
            }
        }

        void UpdateGraphic() {
            if (mod1 && !mod2) {
                baseG.SetActive(false);
                mod1G.SetActive(true);
            } else if (!mod1 && mod2) {
                baseG.SetActive(false);
                mod2G.SetActive(true);
            } else if (mod1 && mod2) {
                mod1G.SetActive(false);
                mod2G.SetActive(false);
                mod12G.SetActive(true);
            } 
        }

        void ResetGraphics() {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(false);
            }
            baseG.SetActive(true);
        }

    }

}
