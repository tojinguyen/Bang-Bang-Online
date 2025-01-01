using MessagePipe;
using UnityEngine;
using VContainer;
#if UNITY_EDITOR
using System.Reflection;
#endif

/// <summary>
/// All units in the game must inherit from this class.
/// </summary>
[DisallowMultipleComponent]
public class BaseUnit : MonoBehaviour
{
    [SerializeField] protected UnitInput unitInput;
    [SerializeField] protected UnitStates unitStates;
    [SerializeField] protected UnitRuntimeStats unitRuntimeStats;
    [SerializeField] protected UnitMovement unitMovement;

    public UnitStates UnitStates => unitStates;
    public UnitRuntimeStats UnitRuntimeStats => unitRuntimeStats;
    public UnitMovement UnitMovement => unitMovement;

    [Inject] private IPublisher<UnitSpawnPayload> _unitSpawnPublisher;

    protected virtual void Awake()
    {
        _unitSpawnPublisher.Publish(new UnitSpawnPayload
        {
            InstanceId = gameObject.GetInstanceID(),
        });
    }

    public virtual void SetupUnit()
    {
        unitRuntimeStats.InitData();
    }

    protected virtual void OnValidate()
    {
        unitInput ??= GetComponentInChildren<UnitInput>();
        unitStates ??= GetComponentInChildren<UnitStates>();
        unitRuntimeStats ??= GetComponentInChildren<UnitRuntimeStats>();
        unitMovement ??= GetComponentInChildren<UnitMovement>();
    }
}