using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Login : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button LoginButton;
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
        // ó���� �̸��� Input Field�� �����ϵ��� �Ѵ�.
        firstInput.Select();
        LoginButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.Login(UsernameInput.text, PasswordInput.text));
            Debug.Log("login");
        });
        RegisterButton.onClick.AddListener(() =>
        {
            Debug.Log("registerCanvasOpen");
            _mainCanvas.RegistCanvas.Show();
            _mainCanvas.LoginCanvas.Hide();
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
            // Tab + LeftShift�� ���� Selectable ��ü�� ����
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (next != null)
            {
                next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Tab�� �Ʒ��� Selectable ��ü�� ����
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            // ����Ű�� ġ�� �α��� (����) ��ư�� Ŭ��
            submitButton.onClick.Invoke();
            Debug.Log("Button pressed!");
        }
    }
}
