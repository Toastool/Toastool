using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Networking;

public class TestConnect : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        print("Connecting to server.");
        PhotonNetwork.NickName = Web.userID;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
       
    }
    IEnumerator Upload()
    {
        string url = "https://toastool-yftor.run.goorm.io?Name=" + UnityWebRequest.EscapeURL(PhotonNetwork.NickName);
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Upload complete!");
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon.", this);

        Debug.Log("My nickname is " + PhotonNetwork.LocalPlayer.NickName, this);
        StartCoroutine(Upload());
        Debug.Log("My nickname will be " + PhotonNetwork.NickName);
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Failed to connect to Photon: " + cause.ToString(), this);
    }

    public override void OnJoinedLobby()
    {
        print("Joined lobby");
    }



}