using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hintcanvas : MonoBehaviour
{
    private void Start() {
        CameraScript.Instance.hintsCanvas = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
