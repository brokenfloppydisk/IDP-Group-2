using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempMoveScenes : MonoBehaviour
{
    public List<string> scenes = new List<string>();
    private int index = 0;
    public void SwitchScenes() {
        SceneManager.LoadScene(scenes[(index +1 % (scenes.Count))-1]);
        index ++;
    }
}
