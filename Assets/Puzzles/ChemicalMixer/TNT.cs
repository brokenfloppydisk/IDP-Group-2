using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TNT : MonoBehaviour
{
    public Animator animator;
    public bool selected;
    public GameObject door;
    public Sprite[] arrowSprites;
    public void explodeDoor() {
        if (selected) {
            animator.SetBool("TNTUsed",true);
            door.SetActive(false);
        }
    }
    public void ClickTnt() {
        if (selected) {
            selected = false;
        } else {
            selected = true;
        }
    }
    private IEnumerable setArrowActive() {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Activator>().Activate();
    }
    private IEnumerable flashingArrow() {
        Image arrow = FindObjectOfType<CameraScript>().hiddenButtons[2].GetComponent<Image>();
        int i = 0;
        while (true) {
            arrow.sprite = arrowSprites[i%2];
            i++;
            yield return new WaitForSeconds(0.5f);
        }
        
        
    }
}
