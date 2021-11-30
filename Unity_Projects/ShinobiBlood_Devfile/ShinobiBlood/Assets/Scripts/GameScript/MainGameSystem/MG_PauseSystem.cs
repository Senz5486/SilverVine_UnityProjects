using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Senz_Program
{
    public class MG_PauseSystem : MonoBehaviour
    {
        bool isPause;
        bool isStartGame;
        [SerializeField] private GameObject PauseUI;
        private MG_HealthSystem _HealthSystem;
        private OR_SceneManager _SceneManager;

        private void Awake()
        {
            PauseUI.SetActive(false);
            _HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            _SceneManager = this.GetComponent<OR_SceneManager>();
        }

        private void Update()
        {
            isStartGame = _HealthSystem.isStart;
            if (isStartGame) {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    isPause = !isPause;
                }
            }
            if(isPause & isStartGame)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else if (!isPause || !isStartGame)
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }

        public void PushRetry()
        {
            isPause = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void PushUnpause()
        {
            isPause = false;
        }

        public void PushBackToMenu()
        {
            isPause = false;
            _SceneManager.SceneName = "MainMenu";
            _SceneManager.NextSceneLoad();
        }

    }
}
