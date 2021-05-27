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
    private void Start() {
        StartCoroutine(startSequence());
    }
    IEnumerator startSequence() {
        yield return new WaitForSeconds(1);
        CameraScript cameraScript = FindObjectOfType<CameraScript>();
        if (cameraScript.mainMenuFirstTime) {
            logoAnimator.SetBool("OpenLogo", true);
            cameraScript.mainMenuFirstTime = false;
        }
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
