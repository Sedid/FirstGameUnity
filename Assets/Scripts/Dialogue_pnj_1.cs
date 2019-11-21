using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_pnj_1 : MonoBehaviour
{
    GameObject dialogue;
    GameObject boiteDialogue;
    // Dialogue_png_1

    private void Start()
    {
        dialogue = GameObject.Find("Dialogue_png_1").gameObject;
        boiteDialogue = GameObject.Find("BoiteDialogue").gameObject;
        dialogue.SetActive(false);
        boiteDialogue.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "joueur")
        {
            dialogue.SetActive(true);
            boiteDialogue.SetActive(true);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "joueur")
        {
            dialogue.SetActive(false);
            boiteDialogue.SetActive(false);
        }
    }
}

