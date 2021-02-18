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
    public GameObject videoScreenPrefab;
    [SerializeField]
    public GameObject videoScreenObject;

    public static string videoName = "";
    public static bool isVideoPlaying = false;
    public static long currentFrame;

    private int x = 0;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject player = Instantiate(playerPrefab, startLocation.position, startLocation.rotation);
        GameObject videoPlayer = Instantiate(videoScreenPrefab, videoScreenObject.transform);
        NetworkIdentity playerId = player.GetComponent<NetworkIdentity>();

        
        
        NetworkServer.AddPlayerForConnection(conn, player);
        playerId.AssignClientAuthority(conn);

        NetworkServer.Spawn(videoPlayer, player);
    }
}
