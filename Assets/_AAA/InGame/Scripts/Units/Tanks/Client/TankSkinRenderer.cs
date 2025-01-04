using Cysharp.Threading.Tasks;
using UnityEngine;

public class TankSkinRenderer : MonoBehaviour
{
    [SerializeField] private TanksConfig _tanksConfig;
    [SerializeField] private Transform _visualRoot;
    
    public async UniTask SetupSkin(TankType tankType)
    {
        var tankConfig = _tanksConfig.GetTankConfig(tankType);
        var tankSkinAssetRef = tankConfig.TankRendererConfig.SkinAssetRef;

        var tankSkinGo = await AddressablesHelper.GetAssetAsync<GameObject>(tankSkinAssetRef, AddressablesFeatureName.InGame);
    }
}
