using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "TankRendererConfig", menuName = "AAA/InGame/Unit/Tanks/TankRendererConfig")]
public class TankRendererConfig : ScriptableObject
{
    [SerializeField] private AssetReferenceGameObject _tankSkin;
}
