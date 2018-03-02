using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{  
        [SyncVar]
        public Color color;

    float moveSpeed = 1.875f;

    public override void OnStartClient()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    private void Update()
    {
        if(isLocalPlayer)
        {
            GetInput();
        }
    }

    void GetInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        if(isServer)
        {
            RpcMoveIt(x, y);
        }
        else
        {
            CmdMoveIt(x, y);
        }
        MoveIt(x, y);
    }

    void MoveIt(float x, float y)
    {
        transform.Translate(x, y, 0);
    }

    [ClientRpc]
    void RpcMoveIt(float x, float y)
    {
        transform.Translate(x, y, 0);
    }

    [Command]
    void CmdMoveIt(float x, float y)
    {
        RpcMoveIt(x, y);
    }

    [Command]
    public void CmdDoFire();
}
