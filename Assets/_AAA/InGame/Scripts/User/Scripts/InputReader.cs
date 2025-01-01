using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int _inputQueueCapacity = 6;
    private const int _delayTicks = 3;

    private readonly Queue<UserInputData> _inputQueue = new(_inputQueueCapacity);

    private void Update()
    {
        
    }
}