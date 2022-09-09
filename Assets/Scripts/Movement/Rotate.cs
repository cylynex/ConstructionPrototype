using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Engine {

    public class Rotate : MonoBehaviour {

        [SerializeField] Vector3 rotation;

        private void Update() {
            transform.Rotate(rotation * Time.deltaTime);
        }

    }

}
