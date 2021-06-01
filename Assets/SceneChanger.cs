using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private string newGameScene = "";
    [SerializeField]
    private int nextAct = 0;
    public void NextScene() {
        GameTimer timer = GameTimer.Instance;
        if (timer != null) {
            timer.act = nextAct;
        }
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame(){
        Application.Quit();
    }
}