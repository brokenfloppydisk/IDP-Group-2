using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAssigner : MonoBehaviour
{
    private void Start() {
        gameObject.GetComponent<Canvas>().worldCamera = CameraScript.Instance.mainCamera;
    }
}
