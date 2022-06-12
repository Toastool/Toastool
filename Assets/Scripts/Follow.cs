using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float speed;

    public Vector2 center;
    public Vector2 size;
    float height;
    float width;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }

    void LateUpdate()
    {
        
        //transform.position = new Vector3(target.position.x, target.position.y, -10f);
        if (GameObject.Find("Player_remodel") != null)
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        else
            transform.position = Vector3.Lerp(transform.position, GameObject.Find("Player_remodel(Clone)").GetComponent<Transform>().position, Time.deltaTime * speed);
        

        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x , -lx + center.x , lx + center.x);

        float ly = size.y * 0.5f - height;
        float clampY = Mathf.Clamp(transform.position.y , -ly + center.y , ly + center.y);

        transform.position = new Vector3(clampX, clampY , -10f);
    }
}
