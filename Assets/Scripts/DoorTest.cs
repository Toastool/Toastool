using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTest : MonoBehaviour
{
    public Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        anim.SetBool("Open", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Open", false);
    }
}
