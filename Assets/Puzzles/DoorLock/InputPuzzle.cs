using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputPuzzle : MonoBehaviour
{
    public Image correctLight;
    public Sprite correctLightSprite;
    public Image bayDoor;
    public Sprite bayDoorOpenSprite;
    public InputField inputField;
    public Animator animator;
    public Button openButton;
    public Sprite correctImage;
    public ThoughtsTrigger thoughts;
    public void TextChanged(string newText) {
        if (newText.ToUpper() == "RARE") {
            PuzzleComplete();
        }
    }
    public void PuzzleComplete() {
        bayDoor.sprite = bayDoorOpenSprite;
        inputField.interactable = false;
        openButton.interactable = false;
        correctLight.sprite = correctLightSprite;
        CameraScript camera = CameraScript.Instance;
        camera.bayDoorOpen = true;
        bayDoor.gameObject.GetComponent<Button>().interactable = true;
        openButton.GetComponent<Image>().sprite = correctImage;
        GameTimer.Instance.RecordTime(1);
        
    }
    public void Awake() {
        CameraScript _cameraScript = CameraScript.Instance;
        if (!_cameraScript.shipActivated) {
            inputField.interactable = false;
            thoughts.sentence = "A panel that controls the door. It doesn't look like it's on.";
        }
        if (_cameraScript.bayDoorOpen) {
            PuzzleComplete();
        } else {
            bayDoor.gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void OpenKeypad() {
        animator.SetBool("KeypadOpen", true);
    }
    public void CloseKeypad() {
        animator.SetBool("KeypadOpen", false);
    }
}
