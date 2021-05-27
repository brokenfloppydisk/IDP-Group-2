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
        GameTimer timer = FindObjectOfType<GameTimer>();
        if (timer) {
            timer.act = nextAct;
        }
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame(){
        Application.Quit();
    }
}