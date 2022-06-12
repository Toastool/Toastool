using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMain : MonoBehaviour
{
    public static LobbyMain Instance;
    public LobbyWeb LobbyWeb;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        LobbyWeb = GetComponent<LobbyWeb>();
    }
}
