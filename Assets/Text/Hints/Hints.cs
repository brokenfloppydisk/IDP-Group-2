using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hints : MonoBehaviour
{
    private static Hints _instance;
    static Hints() {
    }
    public static Hints Instance {
        get {
            if (_instance == null) {
                Debug.Log("Hints are null");
            }
            return _instance;
        } set {}
    }
    public SceneIndexer sceneIndexer = null;
    [SerializeField]
    private Text text = null;
    [SerializeField]
    private Button[] closeButtons = null;
    [SerializeField]
    public Button[] openButtons = null;
    [System.NonSerialized]
    public TextManager textManager = null;
    [System.NonSerialized]
    public GameTimer gameTimer = null;
    public Animator animator = null;
    public bool[] alreadyInitializedText = new bool[] {false,false,false,false,false};
    public TextObject[] textObjects = new TextObject[] {null,null,null,null,null};
    public int[] indices = new int[] {0,0,0,0,0};
    public int[] usedHints = new int[] {0,0,0,0,0};
    [SerializeField]
    private GameObject canvas = null;

    private void Awake() {
        _instance = this;
        CameraScript.Instance.hints = this;
        GameObject.DontDestroyOnLoad(canvas);
    }
    private void Start() {
        gameTimer = GameTimer.Instance;
        textManager = TextManager.Instance;
    }
    public void UpdatePromptText(float minutes) {
        text.text = "Asking for assistance from Earth will take " + Mathf.RoundToInt(minutes) + " minute" + (minutes > 1 ? "s" : "");
    }
    public void ShowHintMenu() {
        for (int i = 0; i < openButtons.Length; i++) {
            openButtons[i].interactable = false;
        }
        for (int i = 0; i < closeButtons.Length; i++) {
            closeButtons[i].interactable = true;
        }
        animator.SetBool("HintsOpen",true);
    }
    public void CloseHintMenu() {
        for (int i = 0; i < closeButtons.Length; i++) {
            closeButtons[i].interactable = false;
        }
        for (int i = 0; i < openButtons.Length; i++) {
            openButtons[i].interactable = true;
        }
        animator.SetBool("HintsOpen", false);
    }
    /*
    IEnumerator MoveHints(int multiplier) {
        hintsObject.transform.position += new Vector3(0,multiplier*3000,0);
        for (int i = 0; i < 25; i++) {
            hintsObject.transform.position += new Vector3(0,multiplier*40,0);
            yield return null;
        }
    }
    */
    public void setText(string text) {
        this.text.text = text;
    }
    public void useHint() {
        sceneIndexer.UseHint();
    }
    public void checkPreviousHints() {
        sceneIndexer.checkPreviousHints();
    }
    public void Reset() {
        alreadyInitializedText = new bool[] {false, false, false, false, false};
        textObjects = new TextObject[] {null,null,null,null,null};
        indices = new int[] {0,0,0,0,0};
        usedHints = new int[] {0,0,0,0,0};
    }
    public void updateCameraScript() {
        CameraScript.Instance.hintsUsed.Clear();
        CameraScript.Instance.hintsUsed.Add(usedHints[0]);
        CameraScript.Instance.hintsUsed.Add(usedHints[2]+usedHints[3]);
        CameraScript.Instance.hintsUsed.Add(usedHints[1]+usedHints[4]);
        gameTimer.RecordPenalties();
    }
    public static void DestroySingleton() {
        Instance = null;
        _instance = null;
    }
}
