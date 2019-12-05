using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnj : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject boiteDialogue;
    public Transform cible;

    private void Start()
    {
        dialogue.SetActive(false);
        boiteDialogue.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("joueur"))
        {
            dialogue.SetActive(true);
            boiteDialogue.SetActive(true);
            transform.LookAt(cible);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("joueur"))
        {
            dialogue.SetActive(false);
            boiteDialogue.SetActive(false);
        }
    }

}

