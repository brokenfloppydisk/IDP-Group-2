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
        FindObjectOfType<CameraScript>().bayDoorOpen = true;
        bayDoor.gameObject.GetComponent<Button>().interactable = true;
        openButton.GetComponent<Image>().sprite = correctImage;
    }
    public void Awake() {
        if (FindObjectOfType<CameraScript>().bayDoorOpen) {
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
