using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public void Start()
        {
            Instance = this;
            Console.WriteLine("Game started!");
        }

        internal void GameOver()
        {
            throw new NotImplementedException();
        }
    }
}
