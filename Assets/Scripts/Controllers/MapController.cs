using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UI;

namespace Engine {

    public class MapController : MonoBehaviour {

        [SerializeField] GameObject projectPanel;

        [SerializeField] List<Project> allProjects = new List<Project>();

        GameController gameController;

        private void Start() {
            gameController = FindObjectOfType<GameController>();
            ShowAllProjects();
            if (gameController.GetProject != null) {
                // They came from a level, reopen the same level panel.
                OpenProjectPanel(gameController.GetProject);
            }
        }

        void ShowAllProjects() {
            for(int i = 0; i < allProjects.Count; i++) {
                //print(allProjects[i].projectName);
            }
        }

        public void OpenProjectPanel(Project project) {
            gameController.SetActiveProject(project);
            print("HERE - GAMECONTROLLER LOAD SAVE DATA");
            projectPanel.SetActive(true);
        }

        public void CloseProjectPanel() {
            projectPanel.GetComponent<ProjectPanel>().Clear();
            gameController.ClearActiveProject();
            projectPanel.SetActive(false);
        }

        public void ChooseLevel() {
            SceneManager.LoadScene("Project1");
        }

    }
}