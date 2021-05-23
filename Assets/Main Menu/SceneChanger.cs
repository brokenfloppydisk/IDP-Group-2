using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private string newGameScene;
    [SerializeField]
    private bool newGame;
    public void NextScene() {
        if (newGame) {
            FindObjectOfType<CameraScript>().startTime = Time.time;
        }
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame(){
        Application.Quit();
    }
}