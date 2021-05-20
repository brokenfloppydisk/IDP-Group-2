using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CipherStartup : MonoBehaviour
{
    public GameObject ciphersButton;
    void Awake() {
        FindObjectOfType<CameraScript>().ciphersButton = this.ciphersButton;
        ciphersButton.SetActive(false);
    }
}
