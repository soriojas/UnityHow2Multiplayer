using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{  
        [SyncVar]
        public Color col;

}
