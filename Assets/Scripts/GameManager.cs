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

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
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
