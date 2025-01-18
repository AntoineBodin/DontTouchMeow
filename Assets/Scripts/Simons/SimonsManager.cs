using Assets.Scripts.Simons;
using System.Collections.Generic;
using UnityEngine;

public class SimonsManager : MonoBehaviour
{
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
}
