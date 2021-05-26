using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TNT : MonoBehaviour
{
    public Animator animator;
    public bool selected;
    public GameObject door;
    public ThoughtsTrigger doorTrigger;
    public ThoughtsTrigger tntTrigger;
    public void ExplodeDoor() {
        if (selected) {
            animator.SetBool("TNTUsed",true);
            door.SetActive(false);
            StartCoroutine(SetArrowActive());
            FindObjectOfType<CameraScript>().firstDoorExploded = true;
            tntTrigger.sentence = "According to the recipe in the safe, this explosive should be powerful enough now.";
            doorTrigger.sentence = "An exploded door. Let's get out of here!";
        }
    }
    public void ReturnToRoom() {
        door.SetActive(false);
        gameObject.GetComponent<Activator>().Activate();
    }
    public void ClickTnt() {
        selected = true;
    }
    private IEnumerator SetArrowActive() {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Activator>().Activate();
    }
}
