using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCutomize : MonoBehaviour {
    [SerializeField]
    private RuntimeAnimatorController afterItem;

    // Shirts, Pants ���̾��Ű���� �̸� ���߾ �ٲپ��ֽø� �˴ϴ�.
    public void changeHairstyle() {
        GameObject.Find("Hairstyle").GetComponent<Animator>().runtimeAnimatorController = afterItem;
        Debug.Log("Test");
    }

    public void changeOutfit() {
        GameObject.Find("Outfit").GetComponent<Animator>().runtimeAnimatorController = afterItem;
    }
}
