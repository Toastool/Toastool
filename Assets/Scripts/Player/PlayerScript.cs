using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public string currentMapName; // transferMap ��ũ��Ʈ�� �ִ� transferMapName ������ ���� ����.

    public float moveSpeed;
    Animator anim;

    public Rigidbody2D RB;
    public Animator AN;
    public SpriteRenderer SR;
    public PhotonView PV;
    public Text NickNameText;

    Vector3 curPos;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        anim = GetComponent<Animator>();
    }

    void Awake()
    {
        //�г��� ǥ��
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;

    }

    void Update()
    {
        if (PV.IsMine)
        {
            // �̵�
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            if (inputX != 0 || inputY != 0)
                anim.SetBool("ismove", true);
            else
                anim.SetBool("ismove", false);

            anim.SetFloat("inputx", inputX);
            anim.SetFloat("inputy", inputY);

            transform.Translate(moveSpeed * Time.deltaTime * new Vector2(inputX, inputY));

            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�.
            viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
            viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //�ٽ� ���� ��ǥ�� ��ȯ�Ѵ�.
            transform.position = worldPos; //��ǥ�� �����Ѵ�.
        }

        //ismine �� �ƴ� �͵��� �ε巴�� ��ġ ����ȭ
       
        else transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 100); //�ε巴�� �̵�
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) //��
        {
            stream.SendNext(transform.position);
            //stream.SendNext(anim);
        }
        else //�� ����
        {
            curPos = (Vector3)stream.ReceiveNext();
        }
    }
}
