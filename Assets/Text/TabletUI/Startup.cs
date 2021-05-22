using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    public int index;
    private void Awake(){
        FindObjectOfType<CameraScript>().hiddenButtons[index] = gameObject;
        gameObject.SetActive(false);
    }
}