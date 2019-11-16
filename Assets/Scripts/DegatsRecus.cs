using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DegatsRecus : MonoBehaviour
{

    public Slider barrePdv;
    Animator animations;
    public string ennemi;
 
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

            }
        if (collision.transform.tag == "ennemi")
            if (collision.transform.GetComponentInParent<EnnemiPoursuite>().attaqueZombie)
            {
                barrePdv.value -= 30;
            }

        if (barrePdv.value <= 0)
        {
            animations.SetBool("anim_mort", true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animations = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
