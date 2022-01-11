using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class TestConnect : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("PastScene"))
        {
            Debug.Log("Connecting to Photon...", this);
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
            PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
            PlayerPrefs.DeleteKey("PastScene");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon.", this);   
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Failed to connect to Photon: " + cause.ToString(), this);
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Player Left Lobby.", this);
        PlayerPrefs.DeleteAll();
    }

}