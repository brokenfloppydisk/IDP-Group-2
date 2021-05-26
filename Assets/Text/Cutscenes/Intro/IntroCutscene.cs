using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#pragma warning disable 0649
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
