using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaquesDuJoueur : MonoBehaviour
{
    public bool enAttaque = false;
    static Animator joueurAnimator;
    public float tempsDAttaque = 0.12f;
    float tempsDebutAttaque;
    Vector3 posAvantFrappe;
    // Start is called before the first frame update
    void Start()
    {
        joueurAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - tempsDebutAttaque > tempsDAttaque)
        {
            if (enAttaque)
            {
                transform.eulerAngles = posAvantFrappe;
            }
            enAttaque = false;
        }
        if(Input.GetButton("Fire2") || Input.GetKeyDown(KeyCode.A))
        {
            joueurAnimator.SetBool("anim_attaquer", true);
            enAttaque = true;
            tempsDebutAttaque = Time.time;
            posAvantFrappe = transform.eulerAngles;

        }
        else
        {
            joueurAnimator.SetBool("anim_attaquer", false);
        }

    }
}
