using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAssigner : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
    }
}
