using System;
using UnityEngine;

public abstract class UnitActionLockByState : BaseAction
{
#if UNITY_EDITOR
    [Header("Debug")]
    public bool Lock;
#endif
    [SerializeField] protected GameObject rootObject;
    [SerializeField] protected LockFlagsSO lockFlagsSO;
    [SerializeField] protected UnitStates unitStates;
    [SerializeField] protected BaseAction[] actionNeedToReset;

    public Action OnLock;
    public Action OnUnlock;
    [SerializeField] private bool _isLocked;

    protected bool IsLocked
    {
        get => _isLocked;
        set => _isLocked = value;
    }

    protected virtual void Awake()
    {
        unitStates.OnStateAdded += OnStateAdded;
        unitStates.OnStateRemoved += OnStateRemoved;
    }

    private void OnEnable()
    {
        IsLocked = false;
    }

    protected virtual void OnDestroy()
    {
        unitStates.OnStateAdded -= OnStateAdded;
        unitStates.OnStateRemoved -= OnStateRemoved;
    }

    private void OnStateRemoved(StateType type)
    {
        CheckLockAction();
    }

    private void OnStateAdded(StateType type)
    {
        CheckLockAction();
    }

    private void CheckLockAction()
    {
        var states = unitStates.UnitStatesList;
        foreach (var state in states)
        {
            if (!lockFlagsSO.IsContains(state)) continue;
            if (!IsLocked)
            {
                IsLocked = true;
                OnLock?.Invoke();
                OnLockComp();
            }

#if UNITY_EDITOR
            Lock = IsLocked;
#endif
            return;
        }

        if (IsLocked)
        {
            IsLocked = false;
            OnUnlock?.Invoke();
            OnUnlockComp(); 
        }

#if UNITY_EDITOR
        Lock = IsLocked;
#endif
    }

    protected virtual void OnLockComp()
    {

    }

    protected virtual void OnUnlockComp()
    {

    }

    public override bool CanExecute() => !IsLocked;

    protected void ResetOtherActions()
    {
        foreach (var action in actionNeedToReset)
        {
            action.ResetAction();
        }
    }

    protected bool ValidateGameObjectInstanceID(int instanceId) => rootObject.GetInstanceID() == instanceId;

    protected virtual void OnValidate()
    {
        var root = transform.root;
        rootObject ??= root.gameObject;
        unitStates ??= root.GetComponentInChildren<UnitStates>();
    }
}
