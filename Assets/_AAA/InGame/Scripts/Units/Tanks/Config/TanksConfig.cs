using UnityEngine;

[CreateAssetMenu(fileName = "TanksConfig", menuName = "Scriptable Objects/TanksConfig")]
public class TanksConfig : ScriptableObject
{
    [SerializeField] private TankConfig[] _tanks;
    
    public TankConfig GetTankConfig(TankType tankType)
    {
        foreach (var tank in _tanks)
        {
            if (tank.TankType == tankType)
            {
                return tank;
            }
        }

        return null;
    }
}
