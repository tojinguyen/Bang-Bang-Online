using UnityEngine;

public class UnitStat : MonoBehaviour
{
    [SerializeField] protected UnitStatType unitStatType;
    [SerializeField] protected UnitRuntimeStats unitRuntimeStats;

    protected float currentValue;
    
    public float CurrentValue => currentValue;

    public virtual void InitValue()
    {
        currentValue = unitRuntimeStats.GetStatValue(unitStatType);
    }

    protected virtual void OnValidate()
    {
        unitRuntimeStats ??= GetComponent<UnitRuntimeStats>();
    }
}
