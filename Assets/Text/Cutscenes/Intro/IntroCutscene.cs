using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroCutscene : MonoBehaviour
{
    private int cutsceneStage = 0;
    [SerializeField]
    private Animator animator;
    public void AdvanceCutscene() {
        if (cutsceneStage < 7) {
            cutsceneStage++;
            animator.SetInteger("IntroSlideNum", cutsceneStage);
        }
        else {
            SceneManager.LoadScene("ObjectLoader");
        }
    }
}
