using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName; // �̵��� ���� �̸�
    [SerializeField]
    private Vector3 Position;
    private PlayerScript thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerScript>(); // �ټ��� ��ü.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player_remodel(Clone)")
        {
            Debug.Log("Hit door");
            if (collision.gameObject.TryGetComponent(out PlayerScript player))
            {
                Debug.Log("Player script found!(TransferMap)");

                player.currentMapName = transferMapName;
                Debug.Log(player.currentMapName);
                SceneManager.LoadScene(transferMapName);
                GameObject.Find("Main Camera").GetComponent<Transform>().position = Position;
                GameObject.Find("Player_remodel(Clone)").GetComponent<Transform>().position = Position;
            }
        }
    }
}