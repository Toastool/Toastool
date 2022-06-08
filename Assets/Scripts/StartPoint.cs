using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; // 맵이 이동, 플레이어가 시작될 위치.
    private PlayerScript thePlayer;
    private Follow theCamera;
    public GameObject isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<Follow>();
        thePlayer = FindObjectOfType<PlayerScript>();

        isPlayer = GameObject.Find("Player(Clone)");
        if (isPlayer != null)
        {
            if (gameObject.TryGetComponent(out PlayerScript player))
            {
                Debug.Log("Player script found!(StartPoint)");
                if (startPoint == player.currentMapName)
                {
                    theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
                    player.transform.position = this.transform.position;
                }
            }
        }
        
        //theCamera = FindObjectOfType<Follow>();
        //thePlayer = FindObjectOfType<PlayerScript>();

        //if(startPoint == thePlayer.currentMapName)
        //{
        //    theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
        //    thePlayer.transform.position = this.transform.position;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
