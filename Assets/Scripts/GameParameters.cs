using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class GameParameters
    {
        //CALM
        public const int CALM_START_INPUT_COUNT = 2;
        public const int CALM_COUNT_STEP = 1;

        public const float CALM_START_DURATION = 1.2f;
        public const float CALM_DURATION_STEP = 0f;

        public const int CALM_TO_ANGRY_STEP_COUNT = 6;

        //ANGRY
        public const int ANGRY_START_INPUT_COUNT = 8;
        public const int ANGRY_COUNT_STEP = 0;

        public const float ANGRY_START_DURATION = 1.2f;
        public const float ANGRY_DURATION_STEP = 0.05f;
        
        public const int ANGRY_TO_XTRA_ANGRY_STEP_COUNT = 8;

        //XTRA_ANGRY
        public const int XTRA_ANGRY_START_INPUT_COUNT = 9;
        public const int XTRA_ANGRY_COUNT_STEP = 1;

        public const float XTRA_ANGRY_START_DURATION = 0.8f;
        public const float XTRA_ANGRY_DURATION_STEP = 0.07f;

        public const int XTRA_ANGRY_TO_VICTORY_STEP_COUNT = 6;
    }
}
