using System;
using System.Collections;
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
            SceneManager.LoadScene("Game");
        }

        private void GoBackToStartMenu()
        {
            SceneManager.LoadScene("StartMenu");
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

        public void StartSequence(SimonSequence sequence)
        {
            if (IsSequencePlaying) return;

            IsSequencePlaying = true;
            StartCoroutine(PlaySequence(sequence));
        }

        private IEnumerator PlaySequence(SimonSequence sequence)
        {
            IsSequencePlaying = true;
            yield return StartCoroutine(SimonsManager.PlaySequenceCoroutine(sequence));
            IsSequencePlaying = false;
        }
    }
}
