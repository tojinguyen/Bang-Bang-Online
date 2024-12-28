
public class TankMovement : UnitMovement
{
    protected override float Speed { get; }

    public override void NetworkFixedUpdate()
    {
        if (!CanExecute())
            return;
        base.NetworkFixedUpdate();
        
        if (FetchInput(out UserInput input))
        {
            Move(input.Movement);
        }
    }
}
