using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public Canvas canvas;
    void Start()
    {
        canvas.worldCamera = FindObjectOfType<Camera>();
    }
}
