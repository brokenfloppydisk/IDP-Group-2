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
    [SerializeField]
    public void NextScene() {
        if (newGame) {
            CameraScript _camera = FindObjectOfType<CameraScript>();
            if (!_camera.firstPlaythrough) {
                _camera.ResetVars();
                newGameScene = "IntroCutscene";
            }
        }
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame(){
        Application.Quit();
    }
}