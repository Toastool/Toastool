using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMove : MonoBehaviour, IPunObservable
{
    public string currentMapName; // transferMap ��ũ��Ʈ�� �ִ� transferMapName ������ ���� ����.

    public float moveSpeed;
    Animator anim;

    public PhotonView PV;
    public Animator AN;
    public SpriteRenderer SR;

    Vector3 curPos;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            if(inputX != 0 || inputY != 0)
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
        else transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 500); //�ε巴�� �̵�
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) //��
        {
            stream.SendNext(transform.position);
        }
        else //�� ����
        {
            curPos = (Vector3)stream.ReceiveNext();

        }
    }
}
