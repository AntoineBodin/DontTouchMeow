using Assets.Scripts;
using Assets.Scripts.Simons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class SimonsManager
{
    public static SimonSequence GenerateNextSimonSequence(GameStatus status)
    {
        int inputCount = 0;
        float inputDuration = 1.2f;

        switch (status.CurrentState)
        {
            case MeowState.CALM:
                inputCount = GameParameters.CALM_START_INPUT_COUNT + status.Step * GameParameters.CALM_COUNT_STEP;
                inputDuration = GameParameters.CALM_START_DURATION - status.Step * GameParameters.CALM_DURATION_STEP;
                break;
            case MeowState.ANGRY:
                inputCount = GameParameters.ANGRY_START_INPUT_COUNT + status.Step * GameParameters.ANGRY_COUNT_STEP;
                inputDuration = GameParameters.ANGRY_START_DURATION - status.Step * GameParameters.ANGRY_DURATION_STEP;
                break;
            case MeowState.XTRA_ANGRY:
                inputCount = GameParameters.XTRA_ANGRY_START_INPUT_COUNT + status.Step * GameParameters.XTRA_ANGRY_COUNT_STEP;
                inputDuration = GameParameters.XTRA_ANGRY_START_DURATION - status.Step * GameParameters.XTRA_ANGRY_DURATION_STEP;
                break;
        }

        return GenerateSequence(inputCount, inputDuration);
    }

    public static SimonSequence GenerateSequence(int length, float inputDuration)
    {
        SimonSequence sequence = new()
        {
            Inputs = new List<SimonInput>()
        };

        for (int i = 0; i < length; i++)
        {
            SimonInput input = new()
            {
                Direction = (SimonInputDirection)Random.Range(0, 4),
                Duration = inputDuration
            };
            sequence.Inputs.Add(input);
        }

        return sequence;
    }

    public static IEnumerator PlaySequenceCoroutine(SimonSequence sequence)
    {
        foreach (SimonInput input in sequence.Inputs)
        {
            switch (input.Direction)
            {
                case SimonInputDirection.UP:
                    InputManager.Instance.SwipeStart(new Vector2(0, -4));
                    yield return new WaitForSeconds(input.Duration / 4);
                    InputManager.Instance.Swipe(new Vector2(0, -2));
                    yield return new WaitForSeconds(input.Duration / 4);
                    InputManager.Instance.Swipe(new Vector2(0, 0));
                    break;
                case SimonInputDirection.DOWN:
                    InputManager.Instance.SwipeStart(new Vector2(0, 0));
                    yield return new WaitForSeconds(input.Duration / 4);
                    InputManager.Instance.Swipe(new Vector2(0, -2));
                    yield return new WaitForSeconds(input.Duration / 4);
                    InputManager.Instance.Swipe(new Vector2(0, -4));
                    break;
                case SimonInputDirection.RIGHT:
                    InputManager.Instance.SwipeStart(new Vector2(-2, -1));
                    yield return new WaitForSeconds(input.Duration / 4);
                    InputManager.Instance.Swipe(new Vector2(0, -1));
                    yield return new WaitForSeconds(input.Duration / 4);
                    InputManager.Instance.Swipe(new Vector2(2, -1));
                    break;
                case SimonInputDirection.LEFT:
                    InputManager.Instance.SwipeStart(new Vector2(2, -1));
                    yield return new WaitForSeconds(input.Duration / 4);
                    InputManager.Instance.Swipe(new Vector2(0, -1));
                    yield return new WaitForSeconds(input.Duration / 4);
                    InputManager.Instance.Swipe(new Vector2(-2, -1));
                    break;
            }
            yield return new WaitForSeconds(input.Duration);
            InputManager.Instance.SwipeEnd();
        }
    }
}
