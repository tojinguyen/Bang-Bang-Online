using UnityEngine;

public class TankUnit : BaseUnit
{
    [SerializeField] protected UserInputHandler userInputHandler;
    
    public UserInputHandler UserInputHandler => userInputHandler;
    
    protected override void OnValidate()
    {
        base.OnValidate();
        userInputHandler ??= GetComponent<UserInputHandler>();
    }
}
