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
    private float timeWithPenalty;
    private float hintPenalty;
    private CameraScript cameraScript;
    private void Start() {
        cameraScript = FindObjectOfType<CameraScript>();
        if (cameraScript.roomVisited[0]) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
        startTime = cameraScript.startTime;
        timeWithPenalty = startTime;
        timerActive = true;
        SceneManager.LoadScene("LabCutscene");
    }
    private void Update() {
        float totalSeconds = Mathf.Round(Time.time-this.timeWithPenalty);
        float seconds = totalSeconds % 60;
        int minutes = (int) (totalSeconds-seconds) / 60;
        if (timerActive) {
            text.text = "Time Elapsed: " + (minutes > 0 ? minutes.ToString() + ":" : "0:") + (seconds < 10 ? "0" : "") + seconds.ToString();
        }
    }
    public void AddPenalty(int minutes) {
        hintPenalty += (60*minutes);
        this.timeWithPenalty = startTime - hintPenalty;
        cameraScript.hintPenalty += (60 * minutes);
    }
}
