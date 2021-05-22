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
    void Start()
    {
        timerActive = true;   
    }

    void Awake() {
        startTime = FindObjectOfType<CameraScript>().startTime;
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        float totalSeconds = Mathf.Round(Time.time-startTime);
        float seconds = totalSeconds % 60;
        int minutes = (int) (totalSeconds-seconds)/60;
        if(timerActive) {
            text.text = "Time Elapsed: " + (minutes > 0 ? minutes.ToString() + ":" : "0:") + (seconds < 10 ? "0" : "") + seconds.ToString();
        }
        
    }
}
