using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordTime : MonoBehaviour
{
    public int act = 0;
    public void RecordGameTime() {
        GameTimer gameTimer = FindObjectOfType<GameTimer>();
        if (gameTimer.act != this.act) {
            gameTimer.RecordTime(this.act);
        }
    }
}
