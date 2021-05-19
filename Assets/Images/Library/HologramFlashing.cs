using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HologramFlashing : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    private int i = 1;
    private int cycles = 0;
    void Update()
    {
        if (cycles == 0) {
            image.sprite = sprites[i % sprites.Length];
            i++; 
            cycles = Random.Range(0,119);
        }
        cycles--;
    }
}
