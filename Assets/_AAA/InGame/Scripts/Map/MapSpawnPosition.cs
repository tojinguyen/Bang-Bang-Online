using UnityEngine;

public class MapSpawnPosition : MonoBehaviour
{
    [SerializeField] private Transform _leftSpawnPosition;
    [SerializeField] private Transform _rightSpawnPosition;
    
    public Vector3 GetSpawnPosition(TeamSide teamSide)
    {
        return teamSide == TeamSide.Team1 ? _leftSpawnPosition.position : _rightSpawnPosition.position;
    }
}
