using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hints : MonoBehaviour
{
    private CameraScript cameraScript;
    public SceneIndexer sceneIndexer;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject hintsObject;
    [SerializeField]
    private Button[] closeButtons;
    [SerializeField]
    public Button[] openButtons;
    [System.NonSerialized]
    public TextManager textManager;
    [System.NonSerialized]
    public GameTimer gameTimer;
    [System.NonSerialized]
    public Animator animator;
    public bool[] alreadyInitializedText = new bool[] {false,false,false,false,false};
    public TextObject[] textObjects = new TextObject[] {null,null,null,null,null};
    public int[] indices = new int[] {0,0,0,0,0};
    public int[] usedHints = new int[] {0,0,0,0,0};

    private void Awake() {
        cameraScript = FindObjectOfType<CameraScript>();
        cameraScript.hints = this;
        hintsObject.transform.position += new Vector3(0,-1000,0);
    }
    private void Start() {
        animator = FindObjectOfType<Animator>();
        gameTimer = FindObjectOfType<GameTimer>();
        textManager = FindObjectOfType<TextManager>();
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
        StartCoroutine(MoveHints(1));
    }
    public void CloseHintMenu() {
        for (int i = 0; i < closeButtons.Length; i++) {
            closeButtons[i].interactable = false;
        }
        for (int i = 0; i < openButtons.Length; i++) {
            openButtons[i].interactable = true;
        }
        StartCoroutine(MoveHints(-1));
    }
    IEnumerator MoveHints(int multiplier) {
        for (int i = 0; i < 124; i++) {
            hintsObject.transform.position += new Vector3(0,multiplier*8,0);
            yield return null;
        }
    }
    public void setText(string text) {
        this.text.text = text;
    }
    public void useHint() {
        sceneIndexer.UseHint();
    }
}
