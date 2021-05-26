using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 0649
public class Arrow : MonoBehaviour
{
    [SerializeField]
    private Sprite[] arrowSprites;
    public void Flash() {
        StartCoroutine(flashingArrow());
    }

    private IEnumerator flashingArrow() {
        Image _arrow = gameObject.GetComponent<Image>();
        int i = 0;
        while (true)
        {
            _arrow.sprite = arrowSprites[i % 2];
            i++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
