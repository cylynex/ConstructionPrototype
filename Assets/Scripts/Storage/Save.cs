using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

namespace Engine {

    [System.Serializable]
    public class SavedProfile {
        public string projectName;
        public List<bool> levelLocks = new List<bool>();
    }

    public class Save : MonoBehaviour {

        public SavedProfile profile;

        GameController gameController;

        private void Start() {
            gameController = GetComponent<GameController>();
        }

        public void SaveCurrentProjectProgress() {

            if (profile == null) {
                Debug.Log("no profile yet - creating");
                profile = new SavedProfile();
            }

            print("Attempting to Save Current Project Progress");
            if (gameController.GetProject != null) {
                print("found an active project to save - go.");

                // The Data
                Project thisProject = gameController.GetProject;
                profile.projectName = thisProject.projectName;
                profile.levelLocks = gameController.LevelLocks;
                
                // The actual Write
                BinaryFormatter bf = new BinaryFormatter();

                //string path = Application.persistentDataPath + "/save.dat";
                string filename = gameController.GetProject.projectName + ".dat";
                string path = Application.persistentDataPath + "/" + filename;
                Debug.Log("saveFile is: " + path);

                if (File.Exists(path))
                    File.Delete(path);

                FileStream fs = File.Open(path, FileMode.OpenOrCreate);
                bf.Serialize(fs, profile);

                fs.Close();

            } else {
                print("no active project is set, nothing to save.");
            }



            

        }

    }
}