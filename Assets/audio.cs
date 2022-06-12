using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Sound.SoundPlay();
    }
}
