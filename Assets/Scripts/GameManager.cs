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
        public GameStatus Status { get; set; } = new GameStatus();
        public bool IsSequencePlaying { get; private set; }
        
        private int _moveCount = 0;
        private SimonSequence _currentSequence;

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public async void StartGame()
        {
            await SceneManager.LoadSceneAsync("Game");
            PlayRound();
        }

        private void PlayRound()
        {
            _currentSequence = GenerateNextSimonSequence();
            StartSequence(_currentSequence);
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
            ResetMoveCount();
            var hasLost = Status.GoToLastCheckpoint();

            if (hasLost)
            {
                GameOver();
            }

            PlayRound();
        }

        public void PetMeow()
        {
            ResetMoveCount();
            var hasWon = Status.GoToNextStep();

            if (hasWon)
            {
                //WIN => display winning screen
            }

            PlayRound();
        }

        private void ResetMoveCount()
        {
            _moveCount = 0;
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

        internal void Move(SimonInputDirection direction)
        {
            if (_currentSequence.Inputs[_moveCount].Direction == direction)
            {
                _moveCount++;
                if (_moveCount == _currentSequence.Inputs.Count)
                {
                    PetMeow();
                }
            }
            else
            {
                CalmMeow();
            }
        }
    }
}
