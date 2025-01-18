using Assets.Scripts.Simons;
using System;
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

        public SimonSequence GenerateNextSimonSequence()
        {
            return SimonsManager.GenerateNextSimonSequence(Status);
        }

        public void CalmMeow()
        {
            var hasLost = Status.GoToLastCheckpoint();

            if (hasLost)
            {
                GameOver();
            }
        }

        public void PetMeow()
        {
            var hasWon = Status.GoToNextStep();
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
