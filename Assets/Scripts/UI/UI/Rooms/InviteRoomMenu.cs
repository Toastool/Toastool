using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class InviteRoomMenu : MonoBehaviour
{
    [SerializeField]
    public InputField CodeInput;

    public Button JoinButton;

    public static string projectCodeName;
    public RoomInfo RoomInfo { get; private set; }

    void Start()
    {
        JoinButton.onClick.AddListener(() =>
        {
            StartCoroutine(LobbyMain.Instance.LobbyWeb.ProjectInvite(CodeInput.text));
            Debug.Log(projectCodeName); //null
            Debug.Log(LobbyWeb.itemDataString);
            PhotonNetwork.JoinRoom(RoomInfo.Name);
            Debug.Log(RoomInfo.Name);
        });
    }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        StartCoroutine(LobbyMain.Instance.LobbyWeb.ProjectInvite(CodeInput.text));
        RoomInfo = roomInfo;
        projectCodeName = roomInfo.Name;
    }
}

