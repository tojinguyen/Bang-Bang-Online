using UnityEngine;

public abstract class UnitMovement : UnitActionLockByState
{
    [SerializeField] private CharacterController _characterController;
    
    protected abstract float Speed { get; }

    protected void Move(Vector2 direction)
    {
        var moveDirectionV3 = new Vector3(direction.x, 0, direction.y).normalized;
        _characterController.Move(moveDirectionV3 * Speed * Sandbox.FixedDeltaTime);
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        _characterController ??= rootObject.GetComponent<CharacterController>();
    }
}
