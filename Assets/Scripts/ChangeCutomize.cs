using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCutomize : MonoBehaviour
{
    [SerializeField]
    private Sprite afterItem;

    // Shirts, Pants 하이어라키에서 이름 맞추어서 바꾸어주시면 됩니다.
    public void changeShirts () {
        GameObject.Find("Shirts").GetComponent<SpriteRenderer>().sprite = afterItem;
    }

    public void changePants() {
        GameObject.Find("Pants").GetComponent<SpriteRenderer>().sprite = afterItem;
    }
}
