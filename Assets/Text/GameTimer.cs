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
    private float totalHintPenalty = 0;
    private float[] hintPenalites = new float[] {0,0,0};
    public int act = 0;
    private CameraScript cameraScript;
    private Hints hints;
    private void Start() {
        hints = FindObjectOfType<Hints>();
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
        startTime = cameraScript.startTime;
        float totalSeconds = Mathf.Round(Time.time-startTime+totalHintPenalty);
        float seconds = totalSeconds % 60;
        int minutes = (int) (totalSeconds-seconds) / 60;
        if (timerActive) {
            text.text = "Time Elapsed: " + (minutes > 0 ? minutes.ToString() + ":" : "0:") + (seconds < 10 ? "0" : "") + seconds.ToString();
        }
        if (minutes >= 40) {
            badEnding();
        }
    }
    private void badEnding() {
        hints.updateCameraScript();
        RecordPenalties();
        
        SceneManager.LoadScene("BadEnding");
        
    }
    public void AddPenalty(int minutes) {
        totalHintPenalty += (60 * minutes);
        hintPenalites[act] += (60 * minutes);
    }
    public void AddPenalty(float minutes) {
        totalHintPenalty += (60 * minutes);
        hintPenalites[act] += (60 * minutes);
    }
    public void RecordTime() {
        cameraScript.times.Add(Time.time);
    }
    public void RecordPenalties() {
        cameraScript.penalties.Clear();
        for (int i = 0; i < 3; i++) {
            cameraScript.penalties.Add(hintPenalites[i]);
        }
    }
    public void Reset() {
        startTime = 0;
        totalHintPenalty = 0;
        hintPenalites = new float[] {0,0,0};
        act = 0;
    }
}
