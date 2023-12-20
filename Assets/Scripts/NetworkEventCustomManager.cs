using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkEventCustomManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("["))
        {
            NetworkManager.Singleton.StartHost();
            //  NetworkManager.Singleton.
        }
        if (Input.GetKeyDown("]"))
        {
            NetworkManager.Singleton.StartClient();

        }
    }

    public void startHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void startClient()
    {
        NetworkManager.Singleton.StartClient();
    }
}
