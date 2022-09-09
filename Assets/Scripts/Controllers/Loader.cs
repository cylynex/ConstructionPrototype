using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Engine {

    public class Loader : MonoBehaviour {

        public void ChangeScene(string sceneName) {
            SceneManager.LoadScene(sceneName);
        }

    }

}