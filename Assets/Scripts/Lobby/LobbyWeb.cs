using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyWeb : MonoBehaviour
{
    [SerializeField]
    public InputField CodeInput;
    public static string itemDataString;
    public RoomInfo RoomInfo { get; private set; }
    public Button JoinButton;
    public static string projectCodeName;

    public IEnumerator Project(string projectname, string projectcode, string projectmember)
    {
        WWWForm form = new WWWForm();
        form.AddField("projectName", projectname);
        form.AddField("projectCode", projectcode);
        form.AddField("projectMember", projectmember);

        using (UnityWebRequest www = UnityWebRequest.Post("https://php-unity-tepob.run.goorm.io/Project.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator ProjectInvite(string projectcode)
    {

        WWWForm form = new WWWForm();
        form.AddField("projectCode", projectcode);

        using (UnityWebRequest www = UnityWebRequest.Post("https://php-unity-tepob.run.goorm.io/ProjectInvite.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text); //aa
                PhotonNetwork.JoinRoom(www.downloadHandler.text);
                yield return www.downloadHandler.text;
                itemDataString = www.downloadHandler.text;
                InviteRoomMenu.projectCodeName = itemDataString;
                PhotonNetwork.JoinRoom(RoomInfo.Name);  //null
                PhotonNetwork.JoinRoom(itemDataString);
                Debug.Log(itemDataString);

                //Debug.Log(InviteRoomMenu.projectCodeName);
            }
        }
    }

    void Start()
    {
        JoinButton.onClick.AddListener(() =>
        {
            StartCoroutine(ProjectInvite(CodeInput.text));
            Debug.Log(projectCodeName); //null
            Debug.Log(itemDataString); //null
            PhotonNetwork.JoinRoom(RoomInfo.Name); //null
            Debug.Log(RoomInfo.Name);
        });
    }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        //StartCoroutine(LobbyMain.Instance.LobbyWeb.ProjectInvite(CodeInput.text));
        RoomInfo = roomInfo;
        itemDataString = roomInfo.Name;
        Debug.Log(itemDataString);
        Debug.Log(roomInfo.Name);
    }
}
