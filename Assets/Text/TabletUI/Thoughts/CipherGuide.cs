using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CipherGuide : MonoBehaviour
{
    private static CipherGuide _instance;
    public static CipherGuide Instance {
        get {
            if (_instance == null) {
                Debug.Log("Cipher Guide is null");
            }
            return _instance;
        } set{}
    }
    [SerializeField]
    private ThoughtsTrigger chip = null;
    private void Awake() {
        _instance = this;
    }
    private void Start() {
        if (CameraScript.Instance.hiddenButtons[1].activeSelf) {
            Disable();
        }
    }
    public void Disable() {
        _instance = null;
        Instance = null;
        chip.gameObject.SetActive(false);
    }
}
