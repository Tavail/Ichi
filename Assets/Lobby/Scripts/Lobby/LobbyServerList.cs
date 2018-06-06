using UnityEngine;
using UnityEngine.Networking.Match;
using System.Collections.Generic;
using UnityEngine.Networking;
using Assets.Lobby.Scripts.Lobby;
using System.Linq;

namespace Assets.Lobby
{
    public class LobbyServerList : MonoBehaviour
    {
        public LobbyManager lobbyManager;
        public LobbyNetworkDiscovery lobbyDiscovery;
        public List<LanConnectionInfo> lanConnections;

        public RectTransform serverListRect;
        public GameObject serverEntryPrefab;
        public GameObject noServerFound;

        protected int currentPage = 0;
        protected int previousPage = 0;

        static Color OddServerColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        static Color EvenServerColor = new Color(.94f, .94f, .94f, 1.0f);

        void OnEnable()
        {
            currentPage = 0;
            previousPage = 0;

            foreach (Transform t in serverListRect)
                Destroy(t.gameObject);

            noServerFound.SetActive(false);

            RequestPage(0);
        }

        private void Update()
        {
            lobbyDiscovery.StartCoroutine("CleanUpExpired");
            if (lanConnections == null || lanConnections.Count != lobbyDiscovery.lanConnections.Keys.ToList().Count)
            {
                RequestPage(currentPage);
            }

            lanConnections = lobbyDiscovery.lanConnections.Keys.ToList();
        }

        public void OnGUIMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
		{
			//if (matches.Count == 0)
			//{
   //             if (currentPage == 0)
   //             {
   //                 noServerFound.SetActive(true);
   //             }

   //             currentPage = previousPage;
               
   //             return;
   //         }

   //         noServerFound.SetActive(false);
   //         foreach (Transform t in serverListRect)
   //             Destroy(t.gameObject);

			//for (int i = 0; i < matches.Count; ++i)
			//{
   //             GameObject o = Instantiate(serverEntryPrefab) as GameObject;

			//	o.GetComponent<LobbyServerEntry>().Populate(matches[i], lobbyManager, (i % 2 == 0) ? OddServerColor : EvenServerColor);

			//	o.transform.SetParent(serverListRect, false);
   //         }
        }

        public void OnGuiLobbyList(List<LanConnectionInfo> results)
        {
            if (results == null || results.Count <= 0)
            {
                if (currentPage == 0)
                {
                    noServerFound.SetActive(true);
                    foreach (Transform t in serverListRect)
                        Destroy(t.gameObject);
                }

                currentPage = previousPage;

                return;
            }

            noServerFound.SetActive(false);
            foreach (Transform t in serverListRect)
                Destroy(t.gameObject);

            for (int i = 0; i < results.Count; ++i)
            {
                GameObject o = Instantiate(serverEntryPrefab) as GameObject;

                o.GetComponent<LobbyServerEntry>().Populate(results[i].FromAddress, lobbyManager, (i % 2 == 0) ? OddServerColor : EvenServerColor);

                o.transform.SetParent(serverListRect, false);
            }

        }

        public void ChangePage(int dir)
        {
            int newPage = Mathf.Max(0, currentPage + dir);

            //if we have no server currently displayed, need we need to refresh page0 first instead of trying to fetch any other page
            if (noServerFound.activeSelf)
                newPage = 0;

            RequestPage(newPage);
        }

        public void RequestPage(int page)
        {
            previousPage = currentPage;
            currentPage = page;
			//lobbyManager.matchMaker.ListMatches(page, 6, "", true, 0, 0, OnGUIMatchList); //For online match making.
            OnGuiLobbyList(lobbyDiscovery.lanConnections.Keys.ToList());
        }
    }
}