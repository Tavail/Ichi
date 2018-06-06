using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Lobby.Scripts.Lobby
{
    public class LobbyNetworkDiscovery : NetworkDiscovery
    {
        private float timeout = 5f;

        public Dictionary<LanConnectionInfo, float> lanConnections = new Dictionary<LanConnectionInfo, float>();

        public override void OnReceivedBroadcast(string fromAddress, string data)
        {
            base.OnReceivedBroadcast(fromAddress, data);

            LanConnectionInfo lanInfo = new LanConnectionInfo(fromAddress, data);

            if (lanConnections.ContainsKey(lanInfo) == false)
            {
                lanConnections.Add(lanInfo, Time.time + timeout);
            }
            else
            {
                lanConnections[lanInfo] = Time.time + timeout;
            }
        }

        private IEnumerator CleanUpExpired()
        {
            bool changed = false;

            var keys = lanConnections.Keys.ToList();
            foreach (var key in keys)
            {
                if (lanConnections[key] <= Time.time)
                {
                    lanConnections.Remove(key);
                    changed = true;
                }
            }
            if (changed)
            {
                  
            }

            yield return new WaitForSeconds(timeout);
        }

        public void StartHost()
        {
            this.Initialize();
            this.StartAsServer();
        }

        public void StartClient()
        {
            this.Initialize();
            this.StartAsClient();
        }
    }
}
