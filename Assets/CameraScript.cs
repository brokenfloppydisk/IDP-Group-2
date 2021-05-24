using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private void Awake() {
        DontDestroyOnLoad(this);
    }
}
