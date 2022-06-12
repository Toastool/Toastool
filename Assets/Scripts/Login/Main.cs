using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;
    public Web Web;

    [SerializeField]
    private Login _loginCanvas;
    public Login LoginCanvas { get { return _loginCanvas; } }

    [SerializeField]
    private Regist _registCanvas;
    public Regist RegistCanvas { get { return _registCanvas; } }


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Web = GetComponent<Web>();
    }
    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        LoginCanvas.FirstInitialize(this);
        RegistCanvas.FirstInitialize(this);
    }

    

}
