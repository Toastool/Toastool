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
        // ó���� �̸��� Input Field�� �����ϵ��� �Ѵ�.
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
