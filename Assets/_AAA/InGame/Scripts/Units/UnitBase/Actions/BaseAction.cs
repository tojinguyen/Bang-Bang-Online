using Netick.Unity;

public abstract class BaseAction : NetworkBehaviour
{
    public abstract bool CanExecute();

    protected virtual void Execute()
    {
    }
    
    internal virtual void ResetAction()
    {
    }
}
