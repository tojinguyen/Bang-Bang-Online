using MessagePipe;
using UnityEngine;
using VContainer;

public class UnitStamina : UnitStat
{
    [SerializeField] private GameObject _rootObject;

    [Inject] IPublisher<StaminaChangePayload> _manaChangePublisher;

    protected override void OnValidate()
    {
        base.OnValidate();
        _rootObject ??= transform.root.gameObject;
        unitStatType = UnitStatType.Mana;
    }

    public override void InitValue()
    {
        base.InitValue();
        _manaChangePublisher.Publish(new StaminaChangePayload
        {
            InstanceId = _rootObject.GetInstanceID(),
            CurrentStamina = currentValue,
            MaxStamina = unitRuntimeStats.GetStatValue(UnitStatType.Mana)
        });
    }

    public void ConsumedStamina(float staminaCost)
    {
        currentValue -= staminaCost;
        currentValue = Mathf.Clamp(currentValue, 0, unitRuntimeStats.GetStatValue(UnitStatType.Mana));
        var maxStamina = unitRuntimeStats.GetStatValue(UnitStatType.Mana);
        _manaChangePublisher.Publish(new StaminaChangePayload
        {
            InstanceId = _rootObject.GetInstanceID(),
            CurrentStamina = currentValue,
            MaxStamina = maxStamina
        });
    }

    public void RegenStamina(float staminaRegen)
    {
        currentValue += staminaRegen;
        var maxStamina = unitRuntimeStats.GetStatValue(UnitStatType.Mana);
        _manaChangePublisher.Publish(new StaminaChangePayload
        {
            InstanceId = _rootObject.GetInstanceID(),
            CurrentStamina = currentValue,
            MaxStamina = maxStamina
        });
    }
}

public struct StaminaChangePayload
{
    public int SceneId;
    public int NetworkId;
    public int InstanceId;
    public float CurrentStamina;
    public float MaxStamina;
}