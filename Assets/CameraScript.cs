using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraScript : MonoBehaviour
{
    private static CameraScript _instance;
    public static CameraScript Instance {
        get {
            if (_instance == null) {
                Debug.LogError("CameraScript is null");
            }
            return _instance;
        } 
        set{

        }
    }
    public Camera mainCamera;
    [System.NonSerialized]
    public GameObject[] hiddenButtons = {null, null, null};
    public float startTime = 0;
    public float endTime = 0;
    public bool firstDoorExploded = false;
    public bool shipActivated = false;
    public bool wiresConnected = false;
    public bool bayDoorOpen = false;
    public bool mainMenuFirstTime = true;
    public bool[] roomVisited = {false, false, false, false, false};
    public List<float> times = new List<float>() {0,0,0};
    public List<float> penalties = new List<float>() {0,0,0};
    public List<int> hintsUsed = new List<int>() {0,0,0};
    public bool firstPlaythrough = true;
    public Hints hints;
    private void Awake() {
        _instance = this;
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("MainMenu");
    }
    public void ResetVars() {
        if (!firstPlaythrough) {
            for (int i = 0; i < hiddenButtons.Length; i++) {
                hiddenButtons[i].SetActive(false);
            }
        } else {
            firstPlaythrough = false;
        }
        startTime = 0;
        endTime = 0;
        firstDoorExploded = false;
        shipActivated = false;
        wiresConnected = false;
        bayDoorOpen = false;
        roomVisited = new bool[] {false, false, false, false, false};
        hiddenButtons = new GameObject[] {null,null,null};
        hints = null;
        times = new List<float>() { 0, 0, 0 };
        penalties.Clear();
        hintsUsed = new List<int>() { 0, 0, 0 };
        GameObject.Destroy(FindObjectOfType<GameTimer>().gameObject);
    }
    public void CalculateTimes(string name) {
        List<object> values = new List<object>();
        values.Add(name);
        DataDump.Initialize();
        calculateTimes(values);
    }
    public void CalculateTimes() {
        List<object> values = new List<object>();
        values.Add("unknown");
        calculateTimes(values);
        
    }
    private void calculateTimes(List<object> Values) {
        List<object> values = Values.ToList();
        DataDump.Initialize();
        bool completed = false;
        if (endTime != 0) {
            completed = true;
        }
        List<float> fillList(List<float> list) {
            List<float> tempList = list.ToList();
            while (tempList.Count < 3) {
                tempList.Add(-1);
            }
            return tempList;
        }
        void formatList(List<float> list) {
            List<float> tempList = list.ToList();
            float temp = 0;
            for (int i = 0; i < 3; i++) {
                values.Add(tempList[i]);
                if (tempList[i]!=-1){
                    temp += tempList[i];
                }
            }
            values.Add(temp);
        }
        values.Add(completed.ToString());
        List<float> _times = new List<float>();
        times = fillList(times);
        for (int i = 0; i < 3; i++) {
            if (times[i]!=-1) {
                if (i == 0) {
                    _times.Add(Mathf.Abs(times[i]-startTime));
                } else {
                    if (times[i-1]!=-1) {
                        _times.Add(Mathf.Abs(times[i]-times[i-1]));
                    } else {
                        _times.Add(-1);
                    }
                }
            }
        }
        formatList(_times);
        List<float> hintsList = fillList(hintsUsed.Select<int, float>(i => i).ToList());
        formatList(hintsUsed.Select<int, float>(i => i).ToList());
        penalties = fillList(penalties);
        formatList(penalties);
        formatList(_times.Zip(penalties, (x, y) => (x!= -1 || y!= -1 ? ((x!= -1 ? x : 0) + (y != -1 ? y : 0)) : -1)).ToList());
        DataDump.CreateEntry("A", "R", values, 0);
    }
}
