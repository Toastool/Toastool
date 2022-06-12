using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;
    private RoomCanvases _roomsCanvases;
    private List<RoomListing> _listings = new List<RoomListing>();
    CreateRoomMenu CreateRoomMenu;
    [SerializeField]
    private Vector3 spawnPoint;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void Spawn()
    {
        PhotonNetwork.Instantiate("Player_remodel", spawnPoint, Quaternion.identity);
        Debug.Log("I'm in the room.(join)");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Join room succesed");

        //_roomsCanvases.CurrentRoomCanvas.Show();
        SceneManager.LoadScene("SampleScene");
        _content.DestroyChildren();
        _listings.Clear();
        //_roomsCanvases.CreateOrJoinRoomCanvas.Hide();
        Spawn();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            else
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index == -1)
                {
                    RoomListing listing = Instantiate(_roomListing, _content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        _listings.Add(listing);
                    }
                }
                else
                {
                    //Modify listing here.
                    //_listings[index].....
                }

            }

        }
    }


}
