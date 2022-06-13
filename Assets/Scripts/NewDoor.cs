using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    private Animator anim;

    [SerializeField]

    private int state = 0;

    private void Awake()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        state = 1;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (state == 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("���� ����");
            anim.SetBool("OpenT", false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            if (state == 1)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                Debug.Log("���� �����");
                anim.SetBool("OpenT", true);
                state = 0;
            }
    }
}
