using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextObject
{
    public string[] titles;
    [TextArea(3,20)]
    public string[] sentences;
    public Color textColor;
    public int fontSize;
    public int titleFontSize;
    public Font[] fonts;
    public Color bgColor;
}
