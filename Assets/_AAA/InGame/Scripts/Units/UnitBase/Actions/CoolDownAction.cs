using System;
using UnityEngine;

public abstract class CoolDownAction : UnitActionLockByState
{
    [SerializeField] protected float cooldownTime;

    private float _currentCooldownTime;

    public override bool CanExecute() => base.CanExecute() && _currentCooldownTime <= 0;

    protected override bool Execute()
    {
        if(!CanExecute())
            return false;
        _currentCooldownTime = cooldownTime;
        return true;
    }

    private void Update()
    {
        if (_currentCooldownTime >= 0)
        {
            _currentCooldownTime -= Time.deltaTime;
        }
    }
}
