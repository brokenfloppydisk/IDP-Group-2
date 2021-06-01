using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    private static Cutscene _startCutscene;
    public static Cutscene StartCutscene {
        get {
            if (_startCutscene == null) {
                Debug.Log("Start Cutscene is null");
            }
            return _startCutscene;
        } set {}
    }
    public Animator animator;
    private CameraScript cameraScript;
    public int index;
    private string[] nextScenes = new string[] {"LabCutscene","StartRoom","CommandRoom","EscapePod","Survey"};
    private void Awake() {
        if (index == 1) {
            _startCutscene = this;
        }
        cameraScript = CameraScript.Instance;
        if (index != 4) {
            if (cameraScript.roomVisited[index]) {
                SceneManager.LoadScene(nextScenes[index]);
            }
            cameraScript.roomVisited[index] = true;
        }
        animator.SetBool("CutsceneOpen", true);
    }
    public void AdvanceCutscene() {
        animator.SetBool("AdvanceText", true);
    }
    public void EndCutscene() {
        animator.SetBool("CutsceneOpen", false);
        if (_startCutscene != null) { _startCutscene = null; }
        StartCoroutine(NextScene());
    }
    public void Next() {
        animator.SetBool("CutsceneOpen", false);
    }
    IEnumerator NextScene() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextScenes[index]);
    }
}
