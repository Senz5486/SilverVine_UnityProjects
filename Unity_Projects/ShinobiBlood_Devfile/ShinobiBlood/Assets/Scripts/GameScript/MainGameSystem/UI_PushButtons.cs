using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Senz_Program
{
    public class UI_PushButtons : MonoBehaviour
    {
        OR_SceneManager _ORSceneManager;
        private void Start()
        {
            _ORSceneManager = this.GetComponent<OR_SceneManager>();
        }
        public void PushRetry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void PushBackToMainMenu()
        {
            _ORSceneManager.SceneName = "MainMenu";
            _ORSceneManager.NextSceneLoad();
        }
    }
}
