using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomname;
    RoomListingsMenu RoomListingsMenu;
    private RoomCanvases _roomCanvases;
    public static GameObject PI;
    public string currentMapName; // transferMap 스크립트에 있는 transferMapName 변수의 값을 저장.

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 20;
        PhotonNetwork.JoinOrCreateRoom(_roomname.text, options, TypedLobby.Default);
    }

    public void Spawn()
    {
       PI =  PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        Follow.mainCam.target = PI.transform;
        Debug.Log("I'm in the room.");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room succesfully.", this);
        //SceneManager.LoadScene("SampleScene");
        _roomCanvases.CurrentRoomCanvas.Show();
        _roomCanvases.CreateOrJoinRoomCanvas.Hide();
        Spawn();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed: " + message, this);
    }
}