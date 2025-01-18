using System;
using Assets.Scripts.Simons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public GameStatus Status { get; set; }

        public bool IsSequencePlaying { get; private set; }

        public void Awake()
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

        public void StartSequence()
        {
            if (IsSequencePlaying) return;

            SimonsManager simonsManager = new SimonsManager();
            SimonSequence sequence = SimonsManager.GenerateSequence(5, 3);
            StartCoroutine(simonsManager.PlaySequenceCoroutine(sequence));
        }

        private void GoBackToStartMenu()
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}
