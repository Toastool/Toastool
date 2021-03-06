using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Regist : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button RegisterButton;
    private Main _mainCanvas;
    EventSystem system;
    public Selectable firstInput;
    public Button submitButton;

    public void FirstInitialize(Main canvases)
    {
        _mainCanvas = canvases;
    }

    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;
        // 처음은 이메일 Input Field를 선택하도록 한다.
        firstInput.Select();
        RegisterButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.Register(UsernameInput.text, PasswordInput.text));
            Debug.Log("regist");
        });

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            // Tab + LeftShift는 위의 Selectable 객체를 선택
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (next != null)
            {
                next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Tab은 아래의 Selectable 객체를 선택
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            // 엔터키를 치면 로그인 (제출) 버튼을 클릭
            submitButton.onClick.Invoke();
            Debug.Log("Button pressed!");
        }
    }
}
