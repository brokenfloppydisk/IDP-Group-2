using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CipherGuide : MonoBehaviour
{
    [SerializeField]
    private ThoughtsTrigger chip = null;
    private void Start() {
        if (CameraScript.Instance.hiddenButtons[1].activeSelf) {
            Disable();
        }
    }
    public void Disable() {
        chip.gameObject.SetActive(false);
    }
}
