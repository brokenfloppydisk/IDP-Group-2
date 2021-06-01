using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour
{
    public void CutsceneAdvance() {
        if (Cutscene.StartCutscene != null) {
            Cutscene.StartCutscene.EndCutscene();
        }
    }
}
