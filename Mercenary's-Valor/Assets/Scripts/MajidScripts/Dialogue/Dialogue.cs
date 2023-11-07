using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public Image charImage;
    [TextArea(2,10)] 
    public string[] sentences;
}
