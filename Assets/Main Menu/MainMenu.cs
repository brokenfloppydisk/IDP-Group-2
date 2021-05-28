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
    private void Start() {
        CameraScript cameraScript = CameraScript.Instance;
        if (cameraScript.mainMenuFirstTime) {
            logoAnimator.SetBool("OpenLogo", true);
            cameraScript.mainMenuFirstTime = false;
        }
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
