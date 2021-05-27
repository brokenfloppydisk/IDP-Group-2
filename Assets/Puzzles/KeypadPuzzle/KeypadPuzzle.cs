using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KeypadPuzzle : MonoBehaviour
{
    public Keypad keypad;
    public List<int> values = new List<int>() {0,0,0};
    public List<int> correctValues = new List<int>() {721,349,416};
    public List<bool> successes = new List<bool>() {false,false,false};
    public List<string> coordinates = new List<string>() {"X","Y","Z"};
    public List<Image> keypadImages = new List<Image>();
    public List<Sprite> keypadSprites = new List<Sprite>();
    public Sprite[] lightImages;
    [System.NonSerialized]
    public CameraScript cameraScript;
    public Animator animator;
    public void Awake() {
        cameraScript = CameraScript.Instance;
    }
    public void checkCompletion() {
        int _successes = 0;
        for (int i = 0; i <successes.Count; i++) {
            if (successes[i]) {
                _successes++;
            }
        }
        if (_successes==3) {
            cameraScript.endTime = Time.time;
            FindObjectOfType<GameTimer>().RecordTime(2);
            SceneManager.LoadScene("GoodEnding");
        }
    }
    
}
