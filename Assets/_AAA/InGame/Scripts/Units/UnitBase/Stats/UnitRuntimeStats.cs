using System;
using System.Collections.Generic;
using UnityEngine;
public abstract class UnitRuntimeStats : MonoBehaviour
{
    [SerializeField] private UnitStat[] unitStats;

    protected Dictionary<UnitStatType, UnitStatData> runtimeStats;
    
    public T GetStatComp<T>() where T : UnitStat
    {
        foreach (var unitStat in unitStats)
        {
            if (unitStat is T t)
                return t;
        }

        return null;
    }

    public void InitData()
    {
        runtimeStats ??= new Dictionary<UnitStatType, UnitStatData>();
        runtimeStats.Clear();
        
        var finalStats = GetFinalRuntimeStats();
        
        // Move data from finalStats to _runtimeStats
        foreach (var stat in finalStats)
        {
            runtimeStats.Add(stat.Key, new UnitStatData(stat.Key, stat.Value));
        }
        
        SetupStats();
    }
    
    protected abstract Dictionary<UnitStatType, float> GetFinalRuntimeStats();

    private void SetupStats()
    {
        foreach (var unitStat in unitStats)
        {
            unitStat.InitValue();
        }
    }

    public float GetStatValue(UnitStatType statType)
    {
        if (!runtimeStats.TryGetValue(statType, out var stat))
            return 0;
        return stat.Value;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        unitStats ??= GetComponentsInChildren<UnitStat>();
    }

    [ContextMenu("Get All Stats")]
    private void GetAllStats()
    {
        unitStats = GetComponentsInChildren<UnitStat>();
    }
#endif
}

public enum ModifyStatType
{
    Percent,
    Flat
}


public class UnitStatData
{
    private UnitStatType _type;
    private float _baseValue;
    private float _flatBonus;
    private float _percentBonus;

    public float Value => _baseValue + _flatBonus + _baseValue * _percentBonus;

    public UnitStatData(UnitStatType type, float baseValue, float flatBonus = 0, float percentBonus = 0)
    {
        _type = type;
        _baseValue = baseValue;
        _flatBonus = flatBonus;
        _percentBonus = percentBonus;
    }

    public void ModifyValue(float value, ModifyStatType modifyStatType)
    {
        switch (modifyStatType)
        {
            case ModifyStatType.Flat:
                _flatBonus += value;
                break;
            case ModifyStatType.Percent:
                _percentBonus += value;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(modifyStatType), modifyStatType, null);
        }
    }
}