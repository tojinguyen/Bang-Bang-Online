
public class TankMovement : UnitMovement
{
    protected TankUnit TankUnit => (TankUnit) baseUnit;
    
    protected override float Speed { get; }

    public override void NetworkFixedUpdate()
    {
        if (!CanExecute())
            return;
        base.NetworkFixedUpdate();

        var moveInput = TankUnit.UserInputHandler.InputData.Movement;
        Move(moveInput);
    }
}
