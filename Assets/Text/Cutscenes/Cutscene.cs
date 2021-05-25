using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public GameObject cutscene;
    public Animator animator;
    private CameraScript cameraScript;
    public int index;
    public GameObject tablet;
    public bool useScale;
    private string[] nextScenes = new string[] {"StartRoom","Library", "EscapePod"};
    private void Awake() {
        cameraScript = FindObjectOfType<CameraScript>();
        if (cameraScript.roomVisited[index]) {
            SceneManager.LoadScene(nextScenes[index]);
        }
        animator.SetBool("CutsceneOpen", true);
        if (useScale) {
            StartCoroutine(changeScale());
        }
        if (index==0) {
            tablet = FindObjectOfType<Tablet>().gameObject;
        }
        cameraScript.roomVisited[index] = true;
    }
    public void AdvanceCutscene() {
        animator.SetBool("AdvanceText", true);
    }
    public void EndCutscene() {
        animator.SetBool("CutsceneOpen", false);
        StartCoroutine(NextScene());
    }

    IEnumerator changeScale() {
        yield return new WaitForSeconds(2);
        tablet.transform.localScale = new Vector3(1,1,1);
    }
    IEnumerator NextScene() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextScenes[index]);
    }
}
