using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DegatsRecus : MonoBehaviour
{

    public Slider barrePdv;
    Animator animations;
    public string ennemi;
    //AudioSource coupDeBatte;
    GameObject bamVFX;

    // Start is called before the first frame update
    void Start()
    {
        animations = GetComponent<Animator>();
        bamVFX = GameObject.Find("CFX_Hit").gameObject;
        bamVFX.SetActive(false);
        //if(GameObject.Find("Joueur"))
        //{
        //    coupDeBatte = GetComponent<AudioSource>();
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != ennemi)
        {
            return;
        }
        
       if(collision.transform.tag == "joueur")
             if (collision.transform.GetComponentInParent<AttaquesDuJoueur>().enAttaque)
            {
                barrePdv.value -= 30;
                Debug.Log("J'attaque le zombie");
                if (bamVFX != null)
                {
                    bamVFX.SetActive(true);
                }
                animations.SetBool("anim_degatsRecus", false);
                //coupDeBatte.Play();
            }
        if (collision.transform.tag == "ennemi")
            if (collision.transform.GetComponentInParent<EnnemiPoursuite>().attaqueZombie)
            {
                barrePdv.value -= 30;
                //Debug.Log("dégâts pris par le joueur");
                animations.SetBool("anim_repos", false);
                animations.SetBool("anim_marcher", false);
                animations.SetBool("anim_attaquer", false);
                animations.SetBool("anim_degatsRecus", true);
            }

        if (barrePdv.value <= 0)
        {
            animations.SetBool("anim_mort", true);
            Destroy(bamVFX);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "ennemi")
            if (collision.transform.GetComponentInParent<EnnemiPoursuite>().attaqueZombie)
            {
                animations.SetBool("anim_degatsRecus", false);
                if (bamVFX != null)
                {
                    bamVFX.SetActive(false);
                }
            }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
