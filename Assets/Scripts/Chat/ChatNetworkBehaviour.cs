using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Video;

public class ChatNetworkBehaviour: NetworkManager
{
    [SerializeField]
    public Transform startLocation;


    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject player = Instantiate(playerPrefab, startLocation.position, startLocation.rotation);
        NetworkIdentity playerId = player.GetComponent<NetworkIdentity>();



        NetworkServer.AddPlayerForConnection(conn, player);
        playerId.AssignClientAuthority(conn);
        Debug.Log(playerId.netId);

    }
}
