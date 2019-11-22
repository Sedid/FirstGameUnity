using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnj1 : MonoBehaviour
{
    GameObject dialogue;
    GameObject boiteDialogue;
    Animator animator;
    public Transform cible;

    private void Start()
    {
        dialogue = GameObject.Find("Dialogue_png_1").gameObject;
        boiteDialogue = GameObject.Find("BoiteDialogue").gameObject;
        dialogue.SetActive(false);
        boiteDialogue.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "joueur")
        {
            dialogue.SetActive(true);
            boiteDialogue.SetActive(true);
            transform.LookAt(cible);
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
    private void Update()
    {
        animator.SetBool("pnj1_repos", true);
    }
}

