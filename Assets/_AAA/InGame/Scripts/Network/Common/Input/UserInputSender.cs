using Netick;
using Netick.Unity;
using UnityEngine;

public class UserInputSender : NetworkEventsListener
{
    private int _tick;
    private UserInputData _inputData;
    
    public override void OnInput(NetworkSandbox sandbox)
    {
        base.OnInput(sandbox);
        if (sandbox.Tick.TickValue > _tick)
        {
            _tick = sandbox.Tick.TickValue;
            _inputData = default;
        }
            
        _inputData = UserInputDataHolder.UserInput;
        _inputData.Tick = sandbox.Tick;
        Sandbox.SetInput(_inputData);
    }
}

public static class UserInputDataHolder
{
    public static UserInputData UserInput;
}

public struct UserInputData : INetworkInput
{
    public int Tick;
    public Vector2 Movement;   
    public Vector2 LookDirection;
    public Vector2 Shoot;
}
