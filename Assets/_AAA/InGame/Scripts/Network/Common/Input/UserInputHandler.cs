using Netick;
using Netick.Unity;
using UnityEngine;

public class UserInputHandler : NetworkEventsListener
{
    public static UserInputData UserInput;

    public override void OnInput(NetworkSandbox sandbox)
    {
        var input = sandbox.GetInput<UserInputData>();
        input.Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        sandbox.SetInput(input);
    }
}

public struct UserInputData : INetworkInput
{
    public int Tick;
    public Vector2 Movement;   
    public Vector2 LookDirection;
    public Vector2 Shoot;
}