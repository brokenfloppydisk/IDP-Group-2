using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameTimer : MonoBehaviour
{
    public bool timerActive;
    public Text text;
    private float startTime {get; set;}
    private CameraScript cameraScript;
    private void Start() {
        cameraScript = FindObjectOfType<CameraScript>();
        startTime = cameraScript.startTime;
        DontDestroyOnLoad(this.gameObject);
        timerActive = true;
    }
    private void Update() {
        float totalSeconds = Mathf.Round(Time.time-this.startTime);
        float seconds = totalSeconds % 60;
        int minutes = (int) (totalSeconds-seconds) / 60;
        if (timerActive) {
            text.text = "Time Elapsed: " + (minutes > 0 ? minutes.ToString() + ":" : "0:") + (seconds < 10 ? "0" : "") + seconds.ToString();
        }
    }
    public void AddTime(int minutes) {
        this.startTime = this.startTime - (60 * minutes);
        cameraScript.startTime = this.startTime;
    }
}
