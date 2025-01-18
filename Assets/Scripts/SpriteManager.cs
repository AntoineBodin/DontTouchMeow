using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class SpriteManager : MonoBehaviour
    {
        public Sprite CalmMeow;
        public Sprite CalmMeowDodge;
        public Sprite CalmMeowPet;
        public Sprite CalmMeowDown;
        public Sprite AngryMeow;
        public Sprite AngryMeowDodge;
        public Sprite AngryMeowPet;
        public Sprite AngryMeowDown;
        public Sprite XtraAngryMeow;
        public Sprite XtraAngryMeowDodge;
        public Sprite XtraAngryMeowPet;
        public Sprite XtraAngryMeowDown;

        public Sprite WinImage;
        public Sprite LoseImage;

        public Sprite WinImageText;
        public Sprite LoseImageText;

        public static SpriteManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

        }

        public Sprite GetBase(GameStatus status)
        {
            switch(status.CurrentState)
            {
                case MeowState.CALM:
                    return CalmMeow;
                case MeowState.ANGRY:
                    return AngryMeow;
                case MeowState.XTRA_ANGRY:
                    return XtraAngryMeow;
            }
            return null;
        }

        public Sprite GetDodge(GameStatus status)
        {
            switch(status.CurrentState) {
                case MeowState.CALM:
                    return CalmMeowDodge;
                case MeowState.ANGRY:
                    return AngryMeowDodge;
                case MeowState.XTRA_ANGRY:
                    return XtraAngryMeowDodge;
            }
            return null;
        }

        public Sprite GetDown(GameStatus status)
        {
            switch(status.CurrentState) {
                case MeowState.CALM:
                    return CalmMeowDown;
                case MeowState.ANGRY:
                    return AngryMeowDown;
                case MeowState.XTRA_ANGRY:
                    return XtraAngryMeowDown;
            }
            return null;
        }

        public Sprite GetPet(GameStatus status)
        {
            switch (status.CurrentState)
            {
                case MeowState.CALM:
                    return CalmMeowPet;
                case MeowState.ANGRY:
                    return AngryMeowPet;
                case MeowState.XTRA_ANGRY:
                    return XtraAngryMeowPet;
            }
            return null;
        }
    }
}
