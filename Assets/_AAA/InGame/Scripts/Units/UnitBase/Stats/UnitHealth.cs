using MessagePipe;
using UnityEngine;
using VContainer;

public class UnitHealth : UnitStat
{
    [SerializeField] private GameObject _rootObject;

    private float _damageReceivedPercentage;

    [Inject] IPublisher<HealthChangePayload> _healthChangePublisher;
    [Inject] IPublisher<UnitDeathPayload> _unitDeathPublisher;

    public float CurrentHealth => currentValue;

    public float DamageReceivedPercentage
    {
        get => _damageReceivedPercentage;
        set
        {
            value = Mathf.Max(0, value);
            _damageReceivedPercentage = value;
        }
    }

    public float CurrentHealthPercentage => currentValue / unitRuntimeStats.GetStatValue(UnitStatType.Health);

    public override void InitValue()
    {
        base.InitValue();
        _damageReceivedPercentage = 1;
        _healthChangePublisher.Publish(new HealthChangePayload
        {
            InstanceId = _rootObject.GetInstanceID(),
            CurrentHealth = currentValue,
            MaxHealth = unitRuntimeStats.GetStatValue(UnitStatType.Health)
        });
    }

    public void TakeDamage(int damage)
    {
        var damageReceived = damage * _damageReceivedPercentage;
        var defense = unitRuntimeStats.GetStatValue(UnitStatType.Defense);
        damageReceived -= defense;
        currentValue -= damageReceived;
        currentValue = Mathf.Clamp(currentValue, 0, unitRuntimeStats.GetStatValue(UnitStatType.Health));
        var maxHealth = unitRuntimeStats.GetStatValue(UnitStatType.Health);
        _healthChangePublisher.Publish(new HealthChangePayload
        {
            InstanceId = _rootObject.GetInstanceID(),
            CurrentHealth = currentValue,
            MaxHealth = maxHealth
        });

        if (currentValue > 0)
            return;
        // Play animation for death -> Return to pool
        _unitDeathPublisher.Publish(new UnitDeathPayload
        {
            InstanceId = _rootObject.GetInstanceID()
        });
    }

    public void RegenHealth(int value)
    {
        currentValue += value;
        currentValue = Mathf.Clamp(currentValue, 0, unitRuntimeStats.GetStatValue(UnitStatType.Health));
        var maxHealth = unitRuntimeStats.GetStatValue(UnitStatType.Health);
        _healthChangePublisher.Publish(new HealthChangePayload
        {
            InstanceId = _rootObject.GetInstanceID(),
            CurrentHealth = currentValue,
            MaxHealth = maxHealth
        });
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        _rootObject ??= transform.root.gameObject;
        unitStatType = UnitStatType.Health;
    }
}

public struct HealthChangePayload
{
    public int InstanceId;
    public float CurrentHealth;
    public float MaxHealth;
}