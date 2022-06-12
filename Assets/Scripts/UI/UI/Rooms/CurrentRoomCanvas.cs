using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;

    private RoomCanvases _roomsCanvases;

    public Text projectCode;
    bool ispause;
    public Button CopyButton;

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

    void Start()
    {
        projectCode.text = CreateRoomMenu.projectcode;
        Debug.Log(projectCode.text);
        projectCode.gameObject.SetActive(false);
        CopyButton.gameObject.SetActive(false);
        ispause = false;
        CopyButton.onClick.AddListener(() =>
        {
            TextEditor te = new TextEditor();
            te.text = projectCode.text;
            te.SelectAll();
            te.Copy();
            Debug.Log("copy");
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //projectCode.gameObject.SetActive(true);
            //CopyButton.gameObject.SetActive(true);
            if (ispause == false)
            {
                projectCode.gameObject.SetActive(true);
                CopyButton.gameObject.SetActive(true);
                ispause = true;
                return;
            }
            else
            {
                projectCode.gameObject.SetActive(false);
                CopyButton.gameObject.SetActive(false);
                ispause = false;
                return;
            }
        }
    }
}