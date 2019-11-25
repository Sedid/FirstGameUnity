using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// permet d'être affiché sur Unity
[System.Serializable]
public class Dialogues
{
    [TextArea(2, 5)]
    public string[] phrases;
    public string nameNpc;
}
