using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webViewButtonX : MonoBehaviour
{
    public void closeWebView() {
        Destroy(GameObject.Find("webViewCanvas(Clone)"));
    }
}
