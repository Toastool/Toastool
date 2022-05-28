using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Regist : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button RegisterButton;

    // Start is called before the first frame update
    void Start()
    {
        RegisterButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.web.Register(UsernameInput.text, PasswordInput.text));
        });

    }
}
