using Assets.Scripts.Simons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonsManager
{
    public SimonSequence GenerateSequence(int length, int inputDuration)
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

    public IEnumerator PlaySequenceCoroutine(SimonSequence sequence)
    {
        foreach (SimonInput input in sequence.Inputs)
        {
            switch (input.Direction)
            {
                case SimonInputDirection.UP:
                    InputManager.Instance.SwipeStart(new Vector2(0, -2));
                    InputManager.Instance.Swipe(new Vector2(0, 2));
                    break;
                case SimonInputDirection.DOWN:
                    InputManager.Instance.SwipeStart(new Vector2(0, 2));
                    InputManager.Instance.Swipe(new Vector2(0, -2));
                    break;
                case SimonInputDirection.RIGHT:
                    InputManager.Instance.SwipeStart(new Vector2(-2, 1));
                    InputManager.Instance.Swipe(new Vector2(2, 1));
                    break;
                case SimonInputDirection.LEFT:
                    InputManager.Instance.SwipeStart(new Vector2(2, 1));
                    InputManager.Instance.Swipe(new Vector2(-2, 1));
                    break;
            }
            yield return new WaitForSeconds(0.3f); // wait for 100 milliseconds
        }
    }
}
