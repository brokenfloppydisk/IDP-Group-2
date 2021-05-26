using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CameraScript>().startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
