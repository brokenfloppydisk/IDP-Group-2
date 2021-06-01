using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TabletActivator : MonoBehaviour
{
    public bool inGUI = false;
    [SerializeField]
    private Text text = null;
    [SerializeField]
    private Font newFont = null;
    public void Click() {
        if (!inGUI) {
            StartCoroutine(changeTablet());
            inGUI = true;
        }
    }
    IEnumerator changeTablet() {
        yield return new WaitForSeconds(1f);
        text.text = "Tablet";
        text.font = newFont;
    } 
}
