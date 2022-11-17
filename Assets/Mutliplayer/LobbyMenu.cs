using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbyMenu : MonoBehaviour
{
    public NetworkManager NetworkWorker;
    public GameObject MENU;

    public void Host()
    {
        NetworkWorker.StartHost();

        MENU.SetActive(false);
    }

    public void SetIP(string IP)
    {
        NetworkWorker.networkAddress = IP;
    }

    public void Join()
    {
        NetworkWorker.StartClient();

        MENU.SetActive(false);
    }

    public void StopHost()
    {
        NetworkWorker.StopHost();

        MENU.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
