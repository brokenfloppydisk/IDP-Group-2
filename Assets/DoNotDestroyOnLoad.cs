using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoNotDestroyOnLoad : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}