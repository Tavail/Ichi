using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System;

public class CustomNetworkManager : NetworkManager {

	public void StartHosting()
    {
        StartMatchMaker();
        matchMaker.CreateMatch("Test", 4, true, "", "", "", 0, 0, OnMatchCreated);
        
    }

    private void OnMatchCreated(bool success, string extendedInfo, MatchInfo responsedata)
    {
        base.StartHost(responsedata);
    }

    private void OnEnable()
    {
        RefreshMatches();
    }

    private void RefreshMatches()
    {
        if (matchMaker == null)
            StartMatchMaker();

        matchMaker.ListMatches(0, 10, "", true, 0, 0, HandleListMatchesComplete);
    }

    /// <summary>
    /// page number
    /// page size
    /// name filtering
    /// private matches
    /// elo score
    /// request domain
    /// call back method
    /// </summary>
    /// <param name="success"></param>
    /// <param name="extendedinfo"></param>
    /// <param name="responsedata"></param>
    private void HandleListMatchesComplete(bool success,
        string extendedinfo,
        List<MatchInfoSnapshot> responsedata)
    {
        AvailableMatchesList.HandleNewMatchList(responsedata);
    }

}
