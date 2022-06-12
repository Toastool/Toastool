using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMove : MonoBehaviour, IPunObservable
{
    public string currentMapName; // transferMap 스크립트에 있는 transferMapName 변수의 값을 저장.

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

            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
            viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
            viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
            transform.position = worldPos; //좌표를 적용한다.
        }
        else transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 500); //부드럽게 이동
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) //나
        {
            stream.SendNext(transform.position);
        }
        else //나 말고
        {
            curPos = (Vector3)stream.ReceiveNext();

        }
    }
}
