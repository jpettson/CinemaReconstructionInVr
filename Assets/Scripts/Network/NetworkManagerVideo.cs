using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Video;

public class NetworkManagerVideo : NetworkManager
{
    [SerializeField]
    public Transform startLocation;
    [SerializeField]
    public Transform videoPlayerLocation;
    public int spawnedPersonas = 0;


    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Vector3 playerStartVector       = new Vector3(-35,0,-8);
      //  Vector3 playerSpawnLocation = new Vector3(-35-spawnedPersonas, 0, -8);
        spawnedPersonas = spawnedPersonas + 1;

        

        GameObject teleportation = Instantiate(spawnPrefabs[2], startLocation.position, startLocation.rotation);
        GameObject teleportationPoints = Instantiate(spawnPrefabs[1], new Vector3(-57.76089f, 1.291264f, -25.77712f), Quaternion.identity);
        
        GameObject player = Instantiate(playerPrefab, startLocation.position, startLocation.rotation);
        GameObject videoPlayer = Instantiate(this.spawnPrefabs[0], videoPlayerLocation.position, videoPlayerLocation.rotation);
        NetworkIdentity playerId = player.GetComponent<NetworkIdentity>();

        
        
        NetworkServer.AddPlayerForConnection(conn, player);
        playerId.AssignClientAuthority(conn);

        NetworkServer.Spawn(teleportation, player);
        NetworkServer.Spawn(teleportationPoints, player);
        NetworkServer.Spawn(videoPlayer, player);

        Debug.Log(playerId.netId);
        Debug.Log(videoPlayer.GetComponent<NetworkIdentity>().netId);
    }
}
