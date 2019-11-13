using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaquesDuJoueur : MonoBehaviour
{
    public bool enAttaque = false;
    static Animator joueurAnimator;
    public float tempsDAttaque = 2f;
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
        print(Time.time - tempsDebutAttaque);
        if(Time.time - tempsDebutAttaque > tempsDAttaque)
        {
            if (enAttaque)
            {
                print("je te remets");
                transform.eulerAngles = posAvantFrappe;
            }
            enAttaque = false;
        }
        if(Input.GetButton("Fire1"))
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
