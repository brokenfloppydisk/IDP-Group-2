using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Activator : MonoBehaviour
{
    [SerializeField]
    private int index = -1;
    [SerializeField]
    private bool usingText = false;
    [SerializeField]
    private bool arrow = false;
    [SerializeField]
    private bool waitUntilDestroy = false;
    [SerializeField]
    private TextTrigger textTrigger = null;
    public void Start() {
        if (CameraScript.Instance.hiddenButtons[index].activeSelf) {
            gameObject.SetActive(false);
        }
    }
    public void Activate() {
        CameraScript.Instance.hiddenButtons[index].SetActive(true);
        if (usingText) {
            textTrigger.TriggerText();
        }
        if (arrow) {
            CameraScript.Instance.hiddenButtons[2].GetComponent<Arrow>().Flash();
        }
        if (waitUntilDestroy) {
            StartCoroutine(WaitUntilDestroy());
        } else {
            gameObject.SetActive(false);
        }
        if (index == 1) {
            CipherGuide.Instance.Disable();
        }
        
    }
    IEnumerator WaitUntilDestroy() {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
