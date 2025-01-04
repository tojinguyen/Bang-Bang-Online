using Netick;
using Netick.Unity;
using UnityEngine;

public class PlayerSpawnerController : NetworkEventsListener
{
   [SerializeField] private NetworkObject _tankPrefab;

   public override void OnClientConnected(NetworkSandbox sandbox, NetworkConnection client)
   {
      base.OnClientConnected(sandbox, client);
      Sandbox.NetworkInstantiate(_tankPrefab.gameObject, Vector3.zero, Quaternion.identity, client);
   }
}
