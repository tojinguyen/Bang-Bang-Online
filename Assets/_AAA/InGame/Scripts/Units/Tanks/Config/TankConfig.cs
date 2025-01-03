using UnityEngine;

[CreateAssetMenu(fileName = "TankConfig", menuName = "AAA/InGame/Unit/Tanks/TankConfig")]
public class TankConfig : ScriptableObject
{
   [SerializeField] private UnitStatConfig _tankStatConfig;
   [SerializeField] private TankRendererConfig _tankRendererConfig;
}
