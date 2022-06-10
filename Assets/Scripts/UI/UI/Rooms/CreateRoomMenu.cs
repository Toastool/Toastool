using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomname;
    RoomListingsMenu RoomListingsMenu;
    private RoomCanvases _roomCanvases;

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
        Guid new_guid = Guid.NewGuid();
        Debug.Log(new_guid.ToString());
    }

    public void Spawn()
    {
        PhotonNetwork.Instantiate("Player_remodel", Vector3.zero, Quaternion.identity);
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