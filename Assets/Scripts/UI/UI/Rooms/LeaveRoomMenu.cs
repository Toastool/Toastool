using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveRoomMenu : MonoBehaviour
{

    private RoomCanvases _roomCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        Debug.Log("Leave the room");
        SceneManager.LoadScene("LobbyScene");
        //_roomCanvases.CurrentRoomCanvas.Hide();
        //_roomCanvases.CreateOrJoinRoomCanvas.Show();
    }
}
