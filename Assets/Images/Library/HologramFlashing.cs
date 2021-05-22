using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HologramFlashing : MonoBehaviour
{

    public float cycleSeconds;
    public Sprite[] spritesList;
    private int i = 1;
    private int cycles = 0;
    [System.NonSerialized]
    public Image image;
    private void Awake() {
        image = gameObject.GetComponent<Image>();
    }
    private void Update()
    {
        if (cycles == 0) {
            image.sprite = spritesList[i % 2];
            if (i%2 == 1) {
                cycles = 5;
            } else {
                cycles = Random.Range(0, (int) (cycleSeconds*60-1));
            }
            i++;
        }
        cycles--;
    }
}
