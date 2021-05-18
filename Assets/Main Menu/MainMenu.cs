using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string newGameScene;
    public void NewGame(){
        FindObjectOfType<CameraScript>().startTime = Time.time;
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
