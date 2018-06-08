using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CustomNetowrkManager : NetworkManager {

	public void HostDeathbattle()
    {
        SetPort(7777);
        NetworkManager.singleton.StartHost();
    }

    public void JoinDeathbattle()
    {
        SetIPAddress();
        SetPort(7777);
        NetworkManager.singleton.StartClient();
    }

    public void HostWIP()
    {
        SetPort(7776);
        NetworkManager.singleton.StartHost();
    }

    public void JoinWIP()
    {
        SetPort(7776);
        SetIPAddress();
        NetworkManager.singleton.StartHost();
    }


    void SetIPAddress()
    {
        NetworkManager.singleton.networkAddress = "127.0.0.1";
    }

    void SetPort(int port)
    {
        NetworkManager.singleton.networkPort = port;
    }
}
