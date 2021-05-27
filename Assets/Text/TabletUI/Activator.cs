using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0649
public class Activator : MonoBehaviour
{
    [SerializeField]
    private int index;
    [SerializeField]
    private bool usingText;
    [SerializeField]
    private bool arrow;
    [SerializeField]
    private bool waitUntilDestroy;
    public void Start() {
        if (CameraScript.Instance.hiddenButtons[index].activeSelf) {
            gameObject.SetActive(false);
        }
    }
    public void Activate() {
        CameraScript.Instance.hiddenButtons[index].SetActive(true);
        if (usingText) {
            FindObjectOfType<TextTrigger>().TriggerText();
        }
        if (arrow) {
            FindObjectOfType<CameraScript>().hiddenButtons[2].GetComponent<Arrow>().Flash();
        }
        if (waitUntilDestroy) {
            StartCoroutine(WaitUntilDestroy());
        } else {
            gameObject.SetActive(false);
        }
        
    }
    IEnumerator WaitUntilDestroy() {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
