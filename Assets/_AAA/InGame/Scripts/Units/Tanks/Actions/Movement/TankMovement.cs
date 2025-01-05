
public class TankMovement : UnitMovement
{
    protected override float Speed => 10;

    public override void NetworkFixedUpdate()
    {
        ConsoleLogger.Log("TankMovement.NetworkFixedUpdate");
        if (!CanExecute())
            return;
        ConsoleLogger.Log("TankMovement.NetworkFixedUpdate");
        base.NetworkFixedUpdate();

        if (baseUnit is not TankUnit tankUnit)
            return;
        var moveInput = tankUnit.UserInputHandler.InputData.Movement;
        Move(moveInput);
    }
}
