using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Engine {

    public class GameController : MonoBehaviour {
        
        [SerializeField] Project project;
        public Project GetProject { get { return project; } }
        [SerializeField] int levelID;
        public int GetLevelID { get { return levelID; } }

        /* Level Data */
        [SerializeField] List<bool> levelLocks = new List<bool>();
        public List<bool> LevelLocks { get { return levelLocks; } }

        /* IAP */
        [SerializeField] int coins;

        void Awake() {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");

            if (objs.Length > 1) {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start() {
            
        }
        
        public void ImportProjectSaveData(SavedProfile data) {
            print("IMPORTING DATA NOW");
            levelLocks = data.levelLocks;
        }

        public void SetActiveProject(Project currentProject) {
            project = currentProject;
            SetupLevelLocks();
            GetComponent<Load>().LoadCurrentProject(project.projectName);
        }

        void SetupLevelLocks() {
            for(int i = 0; i < project.levels.Count; i++) {
                levelLocks.Add(false);
            }
            levelLocks[0] = true;
        }

        
        public void SetLevelToLoad(int levelNumber) {
            levelID = levelNumber;
        }

        public void ClearActiveProject() {
            project = null;
        }

        public void UnlockNextLevel() {
            int nextLevel = levelID + 1;
            if (nextLevel < levelLocks.Count) {
                print("There's another level to unlock, go ahead");
                levelLocks[nextLevel] = true;
                // Save progress now
                GetComponent<Save>().SaveCurrentProjectProgress();
            } else {
                print("final level complete");
            }
        }

    }

}
