using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public GameObject[] cutscenes;
    public Animator animator;
    private CameraScript cameraScript;
    public int index;
    public GameObject tablet;
    public bool useScale;
    private void Awake() {
        cameraScript = FindObjectOfType<CameraScript>();
        if (!cameraScript.roomVisited[index]) {
            animator.SetBool("CutsceneOpen", true);
            cameraScript.roomVisited[index] = true;
            if (useScale) {
                StartCoroutine(changeScale());
            }
        } else {
            for (int i = 0; i < cutscenes.Length; i++)
            {
                cutscenes[i].transform.position -= new Vector3(0, 1000, 0);
            }
        }
    }
    public void AdvanceCutscene() {
        animator.SetBool("AdvanceText", true);
    }
    public void EndCutscene() {
        animator.SetBool("CutsceneOpen", false);
    }
    IEnumerator changeScale() {
        yield return new WaitForSeconds(2);
        tablet.transform.localScale = new Vector3(1,1,1);
    }
}
