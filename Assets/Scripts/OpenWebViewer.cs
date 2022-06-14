using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWebViewer : MonoBehaviour
{
    [SerializeField]
    private GameObject WebViewPrefab;
    [SerializeField]
    private string url;

    private int state = 0;
    private int time = 0;

    private void Awake() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        state = 1;
    }

    private void OnCollisionStay2D(Collision2D collision) {
    }

    private void OnCollisionExit2D(Collision2D collision) {
        state = 0;
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.Z)) {
            //if (state == 1) {
            //    if (!GameObject.Find("webViewCanvas(Clone)")) {
            //        Instantiate(WebViewPrefab);
            //        state = 0;
            //    }
            //}
            if (url != "x")
                Application.OpenURL(url);
        }
    }
}
