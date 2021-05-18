using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatorStartup : MonoBehaviour
{
    public GameObject translateButton;
    public Translator translator;
    void Awake() {
        CameraScript camera = FindObjectOfType<CameraScript>();
        camera.translator = this.translator;
        camera.translateButton = this.translateButton;
        translateButton.SetActive(false);
    }
}
