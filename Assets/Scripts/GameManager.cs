using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public GameStatus Status { get; set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void StartGame()
        {

        }

        public void CalmMeow()
        {
            switch (Status.CurrentState)
            {
                case MeowState.CALM:
                    break;
                case MeowState.ANGRY:
                    Status.CurrentState = MeowState.CALM;
                    break;
                case MeowState.XTRA_ANGRY:
                    Status.CurrentState = MeowState.ANGRY;
                    break;
            }
        }

        public void PetMeow()
        {
            switch (Status.CurrentState)
            {
                case MeowState.CALM:
                    Status.CurrentState = MeowState.ANGRY;
                    break;
                case MeowState.ANGRY:
                    Status.CurrentState = MeowState.XTRA_ANGRY;
                    break;
                case MeowState.XTRA_ANGRY:
                    GameOver();
                    break;
            }
        }

        internal void GameOver()
        {
            throw new NotImplementedException();
        }

        private void GoBackToStartMenu()
        {
            SceneManager.LoadScene("StartMenu");
        }

        private void Start()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
