using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TNT : MonoBehaviour
{
    public Animator animator;
    public bool selected;
    public GameObject door;
    public void ExplodeDoor() {
        if (selected) {
            animator.SetBool("TNTUsed",true);
            door.SetActive(false);
            StartCoroutine(SetArrowActive());
            FindObjectOfType<CameraScript>().firstDoorExploded = true;
        }
    }
    public void ReturnToRoom() {
        door.SetActive(false);
        gameObject.GetComponent<Activator>().Activate();
    }
    public void ClickTnt() {
        if (selected) {
            selected = false;
        } else {
            selected = true;
        }
    }
    private IEnumerator SetArrowActive() {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Activator>().Activate();
    }
}
