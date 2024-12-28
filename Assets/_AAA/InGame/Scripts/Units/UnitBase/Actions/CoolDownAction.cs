using Netick;
using UnityEngine;

public abstract class CoolDownAction : UnitActionLockByState
{
    [SerializeField] protected float cooldownTime;

    [Networked] private float CurrentCooldownTime { get; set; }

    public override bool CanExecute() => base.CanExecute() && CurrentCooldownTime <= 0;

    protected override bool Execute()
    {
        if(!CanExecute())
            return false;
        CurrentCooldownTime = cooldownTime;
        return true;
    }

    public override void NetworkFixedUpdate()
    {
        base.NetworkFixedUpdate();
        if (CurrentCooldownTime >= 0)
        {
            CurrentCooldownTime -= Time.fixedDeltaTime;
        }
    }
}
