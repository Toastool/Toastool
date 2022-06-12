using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    private bool state;
    public GameObject Target;

    // Use this for initialization
    private void Start()
    {
        state = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (state == true)
            {
                Target.SetActive(false);
                state = false;
            }

            else
            {
                Target.SetActive(true);
                state = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player_remodel")
        {
              
        }
    }
}
