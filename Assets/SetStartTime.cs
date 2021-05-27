using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartTime : MonoBehaviour
{
    private void Start() {
        CameraScript.Instance.startTime = Time.time;
    }
}
