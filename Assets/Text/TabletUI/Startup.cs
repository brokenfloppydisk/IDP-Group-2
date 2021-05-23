using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    public int index;
    private void Start(){
        FindObjectOfType<CameraScript>().hiddenButtons[index] = gameObject;
        gameObject.SetActive(false);
    }
}