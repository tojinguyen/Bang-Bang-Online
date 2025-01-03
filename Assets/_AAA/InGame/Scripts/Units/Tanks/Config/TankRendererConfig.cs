using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TankRendererConfig", menuName = "AAA/InGame/Unit/Tanks/TankRendererConfig")]
public class TankRendererConfig : ScriptableObject
{
    [System.Serializable]
    public class TankSkin
    {
        public SkinType SkinType; 
        public GameObject prefab;
        public Material Material;
    }

    [SerializeField] private List<TankSkin> _tankSkins;
}

public enum SkinType
{
    Default = 0,
    Golden = 1,
    Silver = 2,
    Stealth = 3,
    Lava = 4,
    Ice = 5,
    Galaxy = 6,
    Neon = 7,
    Shadow = 8,
}
