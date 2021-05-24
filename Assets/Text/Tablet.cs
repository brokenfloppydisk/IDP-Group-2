using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour
{
    public void CutsceneAdvance() {
        Cutscene cutscene = FindObjectOfType<Cutscene>();
        if (cutscene) {
            if (cutscene.index == 0) {
                cutscene.EndCutscene();
            }
        }
    }
}
