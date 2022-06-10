using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCutomize : MonoBehaviour {
    [SerializeField]
    private RuntimeAnimatorController afterItem;

    // Shirts, Pants 하이어라키에서 이름 맞추어서 바꾸어주시면 됩니다.
    public void changeHairstyle() {
        GameObject.Find("Hairstyle").GetComponent<Animator>().runtimeAnimatorController = afterItem;
        Debug.Log("Test");
    }

    public void changeOutfit() {
        GameObject.Find("Outfit").GetComponent<Animator>().runtimeAnimatorController = afterItem;
    }
}
