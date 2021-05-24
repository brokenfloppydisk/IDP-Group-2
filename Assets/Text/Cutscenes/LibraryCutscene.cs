using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryCutscene : MonoBehaviour
{
    public GameObject cutscene;
    public Animator animator;
    public CameraScript cameraScript;
    private void Awake() {
        cameraScript = FindObjectOfType<CameraScript>();
        if (!cameraScript.roomVisited[1]) {
            animator.SetBool("CutsceneOpen", true);
            cutscene.transform.position += new Vector3(0, 1000, 0);
            cameraScript.roomVisited[1] = true;
        }
    }
    public void AdvanceCutscene() {
        animator.SetBool("AdvanceText", true);
    }
    public void EndCutscene() {
        animator.SetBool("CutsceneOpen", false);
    }
}
