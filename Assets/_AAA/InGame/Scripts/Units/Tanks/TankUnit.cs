using Netick;
using UnityEngine;

public class TankUnit : BaseUnit
{
    [SerializeField] protected UserInputHandler userInputHandler;
    
    [Networked] public UserMatchInfo UserMatchInfo { get; set; }
    
    public UserInputHandler UserInputHandler => userInputHandler;
    
    protected override void OnValidate()
    {
        base.OnValidate();
        userInputHandler ??= GetComponent<UserInputHandler>();
    }
}
