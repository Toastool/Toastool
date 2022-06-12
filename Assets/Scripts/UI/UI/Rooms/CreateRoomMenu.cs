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
<<<<<<< Updated upstream
    [SerializeField]
    private Vector3 position;
=======
    public static Guid new_guid;
    public static string projectcode;
>>>>>>> Stashed changes

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
        StartCoroutine(LobbyMain.Instance.LobbyWeb.Project(_roomname.text, new_guid.ToString(), PhotonNetwork.NickName));
        projectcode = new_guid.ToString();
        Debug.Log("project info post");
    }

    public void Spawn()
    {
<<<<<<< Updated upstream
        PhotonNetwork.Instantiate("Player_remodel", position, Quaternion.identity);
        Debug.Log("I'm in the room.");
=======
        PhotonNetwork.Instantiate("Player_remodel", Vector3.zero, Quaternion.identity);
        Debug.Log("I'm in the room.(create)");
>>>>>>> Stashed changes
    }

    public override void OnCreatedRoom()
    {

        Debug.Log("Created room succesfully.", this);
        SceneManager.LoadScene("SampleScene");
        //_roomCanvases.CurrentRoomCanvas.Show();
        //_roomCanvases.CreateOrJoinRoomCanvas.Hide();
        //Spawn();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed: " + message, this);
    }
}