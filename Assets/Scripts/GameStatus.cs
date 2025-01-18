using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Scripts
{
    public class GameStatus
    {
        public MeowState CurrentState { get; set; } = MeowState.CALM;
        public int Step { get; set; } = 0;

        public GameStatus()
        {
            CurrentState = MeowState.CALM;
            Step = 0;
        }

        internal bool GoToLastCheckpoint()
        {
            if (CurrentState == MeowState.CALM) 
            {
                if (Step == 0)
                {
                    return true;
                }
            }
            else if (CurrentState == MeowState.ANGRY)
            {
                if (Step == 0)
                {
                    CurrentState = MeowState.CALM;
                }
            }
            else if (CurrentState == MeowState.XTRA_ANGRY)
            {
                if (Step == 0)
                {
                    CurrentState = MeowState.ANGRY;
                }
            }
            Step = 0;
            return false;
        }

        internal bool GoToNextStep()
        {
            Step++;
            if (CurrentState == MeowState.CALM && Step == GameParameters.CALM_TO_ANGRY_STEP_COUNT)
            {
                Step = 0;
                CurrentState = MeowState.ANGRY;
            }
            else if (CurrentState == MeowState.ANGRY && Step == GameParameters.ANGRY_TO_XTRA_ANGRY_STEP_COUNT)
            {
                Step = 0;
                CurrentState = MeowState.ANGRY;
            }
            else if (CurrentState == MeowState.XTRA_ANGRY && Step == GameParameters.XTRA_ANGRY_TO_VICTORY_STEP_COUNT)
            {
                return true;
            }
            return false;
        }
    }
}
