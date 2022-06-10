using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public string currentMapName; // transferMap 스크립트에 있는 transferMapName 변수의 값을 저장.

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
        //닉네임 표시
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;

    }

    void Update()
    {
        if (PV.IsMine)
        {
            // 이동
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            if (inputX != 0 || inputY != 0)
                anim.SetBool("ismove", true);
            else
                anim.SetBool("ismove", false);

            anim.SetFloat("inputx", inputX);
            anim.SetFloat("inputy", inputY);

            transform.Translate(moveSpeed * Time.deltaTime * new Vector2(inputX, inputY));

            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
            viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
            viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
            transform.position = worldPos; //좌표를 적용한다.
        }

        //ismine 이 아닌 것들은 부드럽게 위치 동기화
       
        else transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 100); //부드럽게 이동
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) //나
        {
            stream.SendNext(transform.position);
            //stream.SendNext(anim);
        }
        else //나 말고
        {
            curPos = (Vector3)stream.ReceiveNext();
        }
    }
}
