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

    // Start is called before the first frame update
    void Start()
    {
        timerActive = true;   
    }

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float totalSeconds = Time.time-startTime;
        float seconds = totalSeconds % 60;
        int minutes = (int) (totalSeconds-seconds)/60;
        if(timerActive) {
            text.text = "Time Elapsed: " + (minutes > 0 ? minutes.ToString() + ":" : "") + seconds.ToString((seconds < 10? "0#.00" : "#.00"));
        }
        
    }
}
