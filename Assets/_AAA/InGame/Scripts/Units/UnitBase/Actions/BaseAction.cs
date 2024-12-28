using Netick.Unity;

public abstract class BaseAction : NetworkBehaviour
{
    public abstract bool CanExecute();

    protected abstract bool Execute();
    
    internal virtual void ResetAction()
    {
    }
}
