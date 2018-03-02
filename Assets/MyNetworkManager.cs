using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerID)
    {
        GameObject playerToSpawn = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternon.identity);
        playerToSpawn.GetComponent<playerControllerID>().color = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        NetworkServer.AddPlayerForConnection(conn, playerToSpawn, playerControllerID);
    }
}
