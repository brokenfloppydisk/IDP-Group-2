using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameTimer : MonoBehaviour
{
    private static GameTimer _instance;
    public static GameTimer Instance {
        get {
            if (_instance == null) {
                Debug.Log("Timer is null");
            }
            return _instance;
        }
        set { }
    }
    public bool timerActive;
    public Text text;
    private float startTime {get; set;}
    private float totalHintPenalty = 0;
    public float[] hintPenalites = new float[] {0,0,0};
    public int act = 0;
    public bool endingLoaded = false;
    private Hints hints;
    private void Awake() {
        _instance = this;
    }
    private void Start() {
        hints = Hints.Instance;
        if (CameraScript.Instance.roomVisited[0]) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
        startTime = CameraScript.Instance.startTime;
        timerActive = true;
        SceneManager.LoadScene("LabCutscene");
    }
    private void Update() {
        startTime = CameraScript.Instance.startTime;
        float totalSeconds = Mathf.Round(Time.time-startTime+totalHintPenalty);
        float seconds = totalSeconds % 60;
        int minutes = (int) (totalSeconds-seconds) / 60;
        if (timerActive) {
            text.text = "Time Elapsed: " + (minutes > 0 ? minutes.ToString() + ":" : "0:") + (seconds < 10 ? "0" : "") + seconds.ToString();
        }
        if (!endingLoaded) {
            if (minutes >= 40) {
                badEnding();
            }
        }
        
    }
    private void badEnding() {
        hints.updateCameraScript();
        RecordPenalties();
        endingLoaded = true;
        
        SceneManager.LoadScene("BadEnding");
        
    }
    public void AddPenalty(int minutes) {
        totalHintPenalty += (60 * minutes);
        hintPenalites[act] += (60 * minutes);
        RecordPenalties();
    }
    public void AddPenalty(float minutes) {
        totalHintPenalty += (60 * minutes);
        hintPenalites[act] += (60 * minutes);
        RecordPenalties();
    }
    public void RecordTime(int act) {
        if (CameraScript.Instance.times.Count-1 < act) {
            Debug.Log("why is the camera script time empty");
        }
        CameraScript.Instance.times[act] = Time.time;
    }
    public void RecordPenalties() {
        CameraScript.Instance.penalties.Clear();
        for (int i = 0; i < 3; i++) {
            CameraScript.Instance.penalties.Add(hintPenalites[i]);
        }
    }
    public void Reset() {
        startTime = 0;
        totalHintPenalty = 0;
        hintPenalites = new float[] {0,0,0};
        act = 0;
    }
    public static void DestroySingleton() {
        Instance = null;
        _instance = null;
    }
}
