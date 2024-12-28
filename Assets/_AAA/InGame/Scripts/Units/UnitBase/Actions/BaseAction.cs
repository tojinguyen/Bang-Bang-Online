using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    public abstract bool CanExecute();

    protected abstract bool Execute();
    
    internal virtual void ResetAction()
    {
    }
}
