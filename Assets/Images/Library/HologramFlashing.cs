using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HologramFlashing : MonoBehaviour
{
    public float seconds;
    public Image image;
    public Sprite[] spritesList;
    private int i = 1;
    private int cycles = 0;
    void Update()
    {
        if (cycles == 0) {
            image.sprite = spritesList[i % 2];
            if (i%2 == 1) {
                cycles = 5;
            } else {
                cycles = Random.Range(0, (int) seconds*60-1);
            }
            i++;
            
        }
        cycles--;
    }
}
