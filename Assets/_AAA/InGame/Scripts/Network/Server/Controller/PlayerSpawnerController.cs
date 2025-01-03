using Netick;
using Netick.Unity;
using UnityEngine;

public class PlayerSpawnerController : NetworkEventsListener
{
   [SerializeField] private NetworkObject _tankPrefab;

   public override void OnClientDisconnected(NetworkSandbox sandbox, NetworkConnection client,
      TransportDisconnectReason transportDisconnectReason)
   {
      base.OnClientDisconnected(sandbox, client, transportDisconnectReason);
   }
}
