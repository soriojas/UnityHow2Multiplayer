using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerID)
    {
        GameObject playerToSpawn = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        playerToSpawn.GetComponent<Player>().color = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        playerToSpawn.GetComponent<Renderer>().material.color = playerToSpawn.GetComponent<Player>.color;
        NetworkServer.AddPlayerForConnection(conn, playerToSpawn, playerControllerID);
    }
}
