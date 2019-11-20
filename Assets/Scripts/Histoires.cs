using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Histoires : MonoBehaviour
{
    public Dialogues dialogue;

    public void DebutHistoires()
    {
        FindObjectOfType<GestionDialogues>().CommencerDialogue(dialogue);
    }
}
