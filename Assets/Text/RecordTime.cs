using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordTime : MonoBehaviour
{
    public int act = 0;
    public void RecordGameTime() {
        if ((FindObjectOfType<CameraScript>().times.Count-1) >= act) {
            FindObjectOfType<GameTimer>().RecordTime();
        }
    }
}
