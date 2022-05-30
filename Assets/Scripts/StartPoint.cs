using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; // ���� �̵�, �÷��̾ ���۵� ��ġ.
    private PlayerMove thePlayer;
    private Follow theCamera;

    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<Follow>();
        thePlayer = FindObjectOfType<PlayerMove>();

        if(startPoint == thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}