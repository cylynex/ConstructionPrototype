using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Engine;

namespace UI { 
    
    public class ProjectPanel : MonoBehaviour {

        [Header("Data")]
        [SerializeField] public Project project;

        [Header("UI")]
        [SerializeField] TMP_Text labelProjectName;
        [SerializeField] TMP_Text labelProjectDescription;
        [SerializeField] Transform levelHolder;
        [SerializeField] TMP_Text winConditions;
        [SerializeField] TMP_Text levelTitle;
        
        [Header("Elements")]
        [SerializeField] GameObject levelButton;
        [SerializeField] Button playButton;

        GameController gameController;
        
        private void Awake() {
            gameController = FindObjectOfType<GameController>();
            //gameObject.SetActive(false);
        }

        private void OnEnable() {
            print("project panel enabled - gamecontroller should already have loaded data for this project.");
            SetupProject(gameController.GetProject);
            //GetComponent<Load>().LoadProject();
            //print("Project: " + gameController.GetProject.projectName);
        }

        public void SetupProject(Project selectedProject) {
            project = selectedProject;
            labelProjectName.text = project.projectName;
            labelProjectDescription.text = project.projectDescription;
            CreateLevelButtons();
        }

        public void Clear() {
            project = null;
            labelProjectName.text = "";
            labelProjectDescription.text = "";
        }

        void CreateLevelButtons() {
            foreach(Transform child in levelHolder) {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < project.levels.Count; i++) {
                // foreach(Level level in project.levels) {
                int index = i;
                GameObject thisLevelButton = Instantiate(levelButton, levelHolder);
                thisLevelButton.GetComponentInChildren<TMP_Text>().text = "Level "+(i+1);
                thisLevelButton.GetComponent<Button>().onClick.AddListener(() => SetLevelToLoad(index));

                if (gameController.LevelLocks[i]) {
                    Image[] lockImage = thisLevelButton.GetComponentsInChildren<Image>();
                    lockImage[1].enabled = false;
                    SetLevelToLoad(index);
                    thisLevelButton.GetComponent<Button>().interactable = true;
                } else {
                    thisLevelButton.GetComponent<Button>().interactable = false;
                }
                
                // TODO - this should be dynamic going off of serialized Save data.  Doing this just for demo
                /*
                if (i > 1) {
                    print("level > 1");
                    thisLevelButton.GetComponent<Button>().enabled = false;
                    ColorBlock buttonColors = thisLevelButton.GetComponent<Button>().colors;
                    buttonColors.normalColor = Color.grey;
                }*/
                
            }
        }

        void SetLevelToLoad(int levelSlot) {
            gameController.SetLevelToLoad(levelSlot);
            winConditions.text = project.levels[levelSlot].winCondition.winDescription;
            levelTitle.text = "Level " + (levelSlot + 1);
            playButton.onClick.AddListener(() => LoadLevel(project.sceneName));
        }

        void LoadLevel(string sceneName) {
            SceneManager.LoadScene(sceneName);
        }

    }

}
