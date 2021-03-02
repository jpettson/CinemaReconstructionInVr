using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Video;

public class Spawnpoint : NetworkManager
{
    [SerializeField]
    public Transform startLocation;
    public int spawnedPersonas = 0;


    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Vector3 playerStartVector = new Vector3(-35, 0, -8);
        Vector3 playerSpawnLocation = new Vector3(-35 - spawnedPersonas, 0, -8);
        spawnedPersonas = spawnedPersonas + 1;




        GameObject player = Instantiate(playerPrefab, playerSpawnLocation, startLocation.rotation);
        
        NetworkIdentity playerId = player.GetComponent<NetworkIdentity>();



        NetworkServer.AddPlayerForConnection(conn, player);
        playerId.AssignClientAuthority(conn);



        Debug.Log(playerId.netId);

    }
}
