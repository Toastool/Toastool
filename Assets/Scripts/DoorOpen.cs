using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    public PlayerScript thePlayer;

    public Animator anim;

    [Tooltip("문이 있으면 : true, 문이 없으면 : false")]
    public bool door; // 문이 있냐 없냐.

    public int door_count;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        //if (!door)
        //{
        //    if (collision.gameObject.name == "Player_remodel")
        //    {
        //        StartCoroutine(TransferCoroutine());
        //    }
        //}
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (door)
        {
            if (collision.gameObject.name == "Player_remodel")
            {
                StartCoroutine(TransferCoroutine());
                //animator.SetBool("Open", true);
            }
            /*
            else
            {
                animator.SetBool("Open", false);
            }
            */
        }
    }

    IEnumerator TransferCoroutine()
    {
        if (door)
        {
            if (door_count == 1)
            {
                anim.SetBool("Open", true);
            }
        }
        yield return new WaitForSeconds(0.3f);

        if (door)
        {
            anim.SetBool("Open", false);
        }
        yield return new WaitForSeconds(0.7f);
    }
}