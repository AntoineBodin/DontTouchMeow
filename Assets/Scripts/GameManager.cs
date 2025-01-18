using System;
using Assets.Scripts.Simons;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public bool IsSequencePlaying { get; private set; }

        public void Start()
        {
            Instance = this;
            Console.WriteLine("Game started!");
        }

        internal void GameOver()
        {
            throw new NotImplementedException();
        }

        public void StartSequence()
        {
            if (IsSequencePlaying) return;

            SimonsManager simonsManager = new SimonsManager();
            SimonSequence sequence = simonsManager.GenerateSequence(5, 3);
            StartCoroutine(simonsManager.PlaySequenceCoroutine(sequence));
        }
    }
}
