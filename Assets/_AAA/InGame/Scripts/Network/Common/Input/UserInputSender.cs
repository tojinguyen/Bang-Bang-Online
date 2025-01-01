using Netick.Unity;

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
            
        _inputData.Tick = sandbox.Tick;
        Sandbox.SetInput(_inputData);
    }
}
