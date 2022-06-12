using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCutomize : MonoBehaviour {
    [SerializeField]
    private RuntimeAnimatorController afterItem;
    [SerializeField]
    private RuntimeAnimatorController body;
    private RuntimeAnimatorController presItem;

    public void changeHairstyle() {
        presItem = GameObject.Find("Hairstyle").GetComponent<Animator>().runtimeAnimatorController;
        if (presItem != afterItem) {
            presItem = GameObject.Find("Outfit").GetComponent<Animator>().runtimeAnimatorController;
            GameObject.Find("Player_remodel(Clone)").GetComponent<Animator>().runtimeAnimatorController = afterItem;
            GameObject.Find("Player_remodel(Clone)").GetComponent<Animator>().runtimeAnimatorController = body;
            GameObject.Find("Hairstyle").GetComponent<Animator>().runtimeAnimatorController = afterItem;
            GameObject.Find("Outfit").GetComponent<Animator>().runtimeAnimatorController = afterItem;
            GameObject.Find("Outfit").GetComponent<Animator>().runtimeAnimatorController = presItem;
        }
    }

    public void changeOutfit() {
        presItem = GameObject.Find("Outfit").GetComponent<Animator>().runtimeAnimatorController;
        if (presItem != afterItem) {
            presItem = GameObject.Find("Hairstyle").GetComponent<Animator>().runtimeAnimatorController;
            GameObject.Find("Player_remodel(Clone)").GetComponent<Animator>().runtimeAnimatorController = afterItem;
            GameObject.Find("Player_remodel(Clone)").GetComponent<Animator>().runtimeAnimatorController = body;
            GameObject.Find("Hairstyle").GetComponent<Animator>().runtimeAnimatorController = afterItem;
            GameObject.Find("Hairstyle").GetComponent<Animator>().runtimeAnimatorController = presItem;
            GameObject.Find("Outfit").GetComponent<Animator>().runtimeAnimatorController = afterItem;
        }
    }
}
