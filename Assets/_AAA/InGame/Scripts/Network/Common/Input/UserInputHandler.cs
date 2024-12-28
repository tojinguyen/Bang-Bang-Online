using Netick.Unity;
using UnityEngine;

public class UserInputHandler : NetworkEventsListener
{
    public override void OnInput(NetworkSandbox sandbox)
    {
        var input = sandbox.GetInput<UserInput>();
        input.Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        sandbox.SetInput(input);
    }
}