using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DegatsRecus : MonoBehaviour
{

    public Slider barrePdv;
    Animator animations;
    public string ennemi;
    GameObject bamVFX;
    public bool mur = false;

    // Start is called before the first frame update
    void Start()
    {
        animations = GetComponent<Animator>();
        if (GameObject.Find("CFX_Hit")) {
            bamVFX = GameObject.Find("CFX_Hit").gameObject;
            bamVFX.SetActive(false);
        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "obstacle")
        {
            mur = true;
        }
        if(collision.gameObject.tag != ennemi)
        {
            return;
        }
        
       if(collision.transform.tag == "joueur")
             if (collision.transform.GetComponentInParent<AttaquesDuJoueur>().enAttaque)
            {
                barrePdv.value -= 30;
                Debug.Log("J'attaque le zombie");
                bamVFX.SetActive(true);
                animations.SetBool("anim_degatsRecus", false);
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
        mur = false;
        print("fin de col");
        if (collision.transform.tag == "ennemi")
            if (collision.transform.GetComponentInParent<EnnemiPoursuite>().attaqueZombie)
            {
                animations.SetBool("anim_degatsRecus", false);
            }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
