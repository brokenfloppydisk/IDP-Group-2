using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject translateButton;
    public Translator translator;
    public float startTime = 0;
    void Awake()
    {
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
