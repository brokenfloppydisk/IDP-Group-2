using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainMenu : SceneChanger
{
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private Animator logoAnimator = null;
    [SerializeField]
    private Animator leaderboardAnimator = null;
    [SerializeField]
    private Animator howToPlayAnimator = null;
    [SerializeField]
    private Animator introButtonAnimator = null; 
    [SerializeField]
    private GameObject introButton;
    [SerializeField]
    private GameObject initializeCanvas;
    private void Start() {
        CameraScript cameraScript = CameraScript.Instance;
        if (cameraScript.mainMenuFirstTime) {
            introButtonAnimator.SetBool("Click",true);
            cameraScript.mainMenuFirstTime = false;
        } else {
            introButton.transform.position += new Vector3(0,-10000,0);
            initializeCanvas.SetActive(false);
        }
    }
    public void PlayLogo() {
        introButtonAnimator.SetBool("Click", false);
        logoAnimator.SetBool("OpenLogo", true);
    }
    public void OpenInstructions() {
        howToPlayAnimator.SetBool("CreditsOpen", true);
    }
    public void CloseInstructions() {
        howToPlayAnimator.SetBool("CreditsOpen", false);
    }
    public void Credits() {
        animator.SetBool("CreditsOpen",true);
    }
    public void CloseCredits() {
        animator.SetBool("CreditsOpen", false);
    }
    public void OpenLeaderboard() {
        leaderboardAnimator.SetBool("LeaderboardOpen", true);
    }
    public void CloseLeaderboard() {
        leaderboardAnimator.SetBool("LeaderboardOpen", false);
    }
}
