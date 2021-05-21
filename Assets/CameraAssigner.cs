using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAssigner : MonoBehaviour
{
    public Canvas canvas;
    public GameObject canvasGameObj;

    void Start()
    {
        canvas = canvasGameObj.GetComponent<Canvas>();
        canvas.worldCamera = FindObjectOfType<Camera>();
    }
}
