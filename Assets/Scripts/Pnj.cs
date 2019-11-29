using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnj : MonoBehaviour
{
    public GameObject dialogue;
   // public GameObject dialogue2;
    public GameObject boiteDialogue;
    Animator animator;
    public Transform cible;

    private void Start()
    {
       // dialogue = GameObject.Find("Dialogue_png_1").gameObject;
        //dialogue2 = GameObject.Find("Dialogue_png_2").gameObject;
        //boiteDialogue = GameObject.Find("BoiteDialogue").gameObject;
        dialogue.SetActive(false);
       // dialogue2.SetActive(false);
        boiteDialogue.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //print("coucou, je suis " + transform.name);
        if (collision.transform.tag == "joueur")
        {
            dialogue.SetActive(true);
         //   dialogue2.SetActive(true);
            boiteDialogue.SetActive(true);
            transform.LookAt(cible);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "joueur")
        {
            dialogue.SetActive(false);
          //  dialogue2.SetActive(false);
            boiteDialogue.SetActive(false);
        }
    }
    private void Update()
    {

        //animator.SetBool("pnj1_repos", true);
    }
}

