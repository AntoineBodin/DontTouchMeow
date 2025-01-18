using System;
using System.Collections;
using Assets.Scripts.Simons;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public GameStatus Status { get; set; } = new GameStatus();
        public bool IsSequencePlaying { get; private set; }

        private int _moveCount = 0;
        private SimonSequence _currentSequence;

        private Image image;

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        private void Start()
        {
        }
        public async void StartGame()
        {
            await SceneManager.LoadSceneAsync("Game");
            image = GameObject.Find("Main Image").GetComponent<Image>();


            StartCoroutine(WaitFor2SecondsBeforePlaying());
        }

        private IEnumerator WaitFor2SecondsBeforePlaying()
        {
            yield return new WaitForSeconds(2);
            Debug.Log("Start Game");
            PlayRound();
        }

        private void PlayRound()
        {
            _currentSequence = GenerateNextSimonSequence();

            _currentSequence.Inputs.ForEach(i => Debug.Log("Direction: " + i.Direction));

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

        public IEnumerator CalmMeow()
        {
            ResetMoveCount();

            var hasLost = Status.GoToLastCheckpoint();

            if (hasLost)
            {
                GameOver();
                yield return new WaitForSeconds(0);
            }

            Sprite baseImage = SpriteManager.Instance.GetBase(Status);
            Sprite dodgeImage = SpriteManager.Instance.GetDodge(Status);
            Sprite downImage = SpriteManager.Instance.GetDown(Status);


            int test = UnityEngine.Random.Range(0, 2);
            if (test == 0)
            {
                yield return Animate(baseImage, dodgeImage);
            }
            else
            {
                yield return Animate(baseImage, downImage);
            }
            
            PlayRound();
        }

        public IEnumerator PetMeow()
        {
            ResetMoveCount();

            var hasWon = Status.GoToNextStep();

            if (hasWon)
            {
                Win();
                yield return new WaitForSeconds(0);
            }

            Sprite baseImage = SpriteManager.Instance.GetBase(Status);
            Sprite petImage = SpriteManager.Instance.GetPet(Status);

            yield return Animate(baseImage, petImage);

            PlayRound();
        }

        private void Win()
        {
            image.sprite = SpriteManager.Instance.WinImage;
        }

        private IEnumerator Animate(Sprite image1, Sprite image2)
        {
            image.sprite = image1;
            yield return new WaitForSeconds(0.5f);
            image.sprite = image2;
            yield return new WaitForSeconds(0.5f);
            image.sprite = image1;
        }

        private void ResetMoveCount()
        {
            _moveCount = 0;
        }

        internal void GameOver()
        {
            image.sprite = SpriteManager.Instance.LoseImage;
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
                    StartCoroutine(PetMeow());
                }
            }
            else
            {
                StartCoroutine(CalmMeow());
            }
        }
    }

}
