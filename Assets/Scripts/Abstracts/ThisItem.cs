using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {

    public class ThisItem : MonoBehaviour {

        [SerializeField] public Item thisItem;
        [SerializeField] public bool isEnabled = false;
        [SerializeField] public bool isUsed = false; // For storage uses only

    }
}