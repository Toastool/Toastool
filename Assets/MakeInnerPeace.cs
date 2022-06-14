using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInnerPeace : MonoBehaviour
{
    static AudioSource audioSource;
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player_remodel(Clone)"))
        {
            audioSource.Play();
        }
    }
}
