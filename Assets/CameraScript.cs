using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;
    [System.NonSerialized]
    public GameObject[] hiddenButtons = {null, null, null};
    public Translator translator;
    public float startTime = 0;
    public float endTime = 0;
    public float hintPenalty = 0;
    public bool firstDoorExploded = false;
    public bool shipActivated = false;
    public bool wiresConnected = false;
    public bool bayDoorOpen = false;
    public bool[] roomVisited = {false,false,false,false, false};
    private void Awake() {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("MainMenu");
    }
    public void ResetVars() {
        hiddenButtons = new GameObject[] {null, null, null};
        startTime = 0;
        endTime = 0;
        hintPenalty = 0;
        firstDoorExploded = false;
        shipActivated = false;
        wiresConnected = false;
        bayDoorOpen = false;
        roomVisited = new bool[] {false, false, false, false, false};
    }
}
