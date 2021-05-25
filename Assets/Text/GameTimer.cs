using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameTimer : MonoBehaviour
{
    public bool timerActive;
    public Text text;
    private float startTime {get; set;}
    private float hintPenalty;
    public int stage = 0;
    private CameraScript cameraScript;
    private void Start() {
        cameraScript = FindObjectOfType<CameraScript>();
        if (cameraScript.roomVisited[0]) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
        startTime = cameraScript.startTime;
        timerActive = true;
        SceneManager.LoadScene("LabCutscene");
    }
    private void Update() {
        float totalSeconds = Mathf.Round(Time.time-startTime+hintPenalty);
        float seconds = totalSeconds % 60;
        int minutes = (int) (totalSeconds-seconds) / 60;
        if (timerActive) {
            text.text = "Time Elapsed: " + (minutes > 0 ? minutes.ToString() + ":" : "0:") + (seconds < 10 ? "0" : "") + seconds.ToString();
        }
        if (minutes >= 40) {
            SceneManager.LoadScene("BadEnding");
        }
    }
    public void AddPenalty(int minutes) {
        hintPenalty += (60*minutes);
    }
    public void RecordTime() {
        cameraScript.penalties.Add(hintPenalty);
        hintPenalty = 0;
        cameraScript.times.Add(Time.time);
    }
}
