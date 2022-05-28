using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;

    private RoomCanvases _roomsCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomsCanvases = canvases;
        _leaveRoomMenu.FirstInitialize(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}