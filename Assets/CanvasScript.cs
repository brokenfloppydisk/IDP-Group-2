using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        canvas.worldCamera = FindObjectOfType<Camera>();
    }
}
