using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName; // �̵��� ���� �̸�

    private PlayerMove thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>(); // �ټ��� ��ü.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            thePlayer.currentMapName = transferMapName;
            SceneManager.LoadScene(transferMapName);
        }
    }
}