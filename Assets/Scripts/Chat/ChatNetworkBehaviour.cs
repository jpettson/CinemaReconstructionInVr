using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Video;

public class ChatNetworkBehaviour: NetworkManager
{
    private bool _isInit = false;
    [SerializeField]
    public Transform startLocation;


    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        if (!_isInit) { 
            GameObject player = Instantiate(playerPrefab, startLocation.position, startLocation.rotation);
            NetworkIdentity playerId = player.GetComponent<NetworkIdentity>();

            NetworkServer.AddPlayerForConnection(conn, player);
            playerId.AssignClientAuthority(conn);
            Debug.Log(playerId.netId);
            _isInit = true;
        }
        else
        {
            GameObject player = Instantiate(playerPrefab, startLocation.position, startLocation.rotation);
            var cc = player.GetComponent<CharacterController>();
            Destroy(cc);
            var cm = player.GetComponent<PlayerMovement>();
            Destroy(cm);
            var chat = player.GetComponent<NetworkBehaviour>();
            Destroy(chat);
            Debug.Log("newplayer joined");
        }
    }
}
