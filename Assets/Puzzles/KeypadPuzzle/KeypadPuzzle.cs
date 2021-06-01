using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KeypadPuzzle : MonoBehaviour
{
    private static KeypadPuzzle _instance;
    public static KeypadPuzzle Instance {
        get {
            if (_instance == null) {
                Debug.Log("Keypad is null");
            }
            return _instance;
        } set{}
    }
    public Keypad keypad;
    public List<int> values = new List<int>() {0,0,0};
    public List<int> correctValues = new List<int>() {721,349,416};
    public List<bool> successes = new List<bool>() {false,false,false};
    public List<string> coordinates = new List<string>() {"X","Y","Z"};
    public List<Image> keypadImages = new List<Image>();
    public List<Sprite> keypadSprites = new List<Sprite>();
    public Sprite[] lightImages;
    public Animator animator;
    private void Awake() {
        _instance = this;
    }
    public void checkCompletion() {
        int _successes = 0;
        for (int i = 0; i <successes.Count; i++) {
            if (successes[i]) {
                _successes++;
            }
        }
        if (_successes==3) {
            CameraScript.Instance.endTime = Time.time;
            GameTimer.Instance.RecordTime(2);
            SceneManager.LoadScene("GoodEnding");
        }
    }
    public static void DestroySingleton() {
        Instance = null;
        _instance = null;
    }
}
