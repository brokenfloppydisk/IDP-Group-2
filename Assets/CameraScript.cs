using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;
    [System.NonSerialized]
    public GameObject[] hiddenButtons = {null, null, null};
    public Translator translator;
    public float startTime = 0;
    public float endTime = 2;
    public bool firstDoorExploded = false;
    public bool shipActivated = false;
    public bool wiresConnected = false;
    public bool bayDoorOpen = false;
    public bool[] roomVisited = {false, false, false, false, false};
    public List<float> times = new List<float>();
    public List<float> penalties = new List<float>();
    public List<int> hintsUsed = new List<int>();
    public bool firstPlaythrough = true;
    public Hints hints;
    private void Awake() {
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
        hints.Reset();
        FindObjectOfType<GameTimer>().Reset();
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
        void formatList(List<float> list) {
            List<float> tempList = list.ToList();
            Debug.Log(3-tempList.Count());
            for (int i = 0; i <(3 - tempList.Count); i++) {
                tempList.Add(-1);
            }
            for (int i = 0; i <tempList.Count; i++) {
                Debug.Log(tempList[i]);
            }
            float temp = 0;
            for (int i = 0; i < tempList.Count; i++) {
                values.Add(tempList[i]);
                if (tempList[i]!=-1){
                    temp += tempList[i];
                }
            }
            values.Add(temp);
        }
        values.Add(completed.ToString());
        List<float> _times = new List<float>();
        for (int i = 0; i < (3 - times.Count); i++) {
            times.Add(-1);
        }
        times.ForEach(x => _times.Add(x != -1 ? (Mathf.Abs(startTime - x)) : -1));
        Debug.Log("times");
        formatList(_times);
        Debug.Log("Hints");
        formatList(hintsUsed.Select<int, float>(i => i).ToList());
        Debug.Log("Hint Penalties");
        formatList(penalties);
        Debug.Log("Adjusted Times");
        formatList(_times.Zip(penalties, (x, y) => x + y).ToList());
        Debug.Log(values.Count);
        DataDump.CreateEntry("A", "R", values, 0);
    }
}
