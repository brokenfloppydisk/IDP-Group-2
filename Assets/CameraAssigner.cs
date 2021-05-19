using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAssigner : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        canvas.worldCamera = FindObjectOfType<Camera>();
    }
}
