using UnityEngine;
using UnityEngine.UI;

public class DegatsRecus : MonoBehaviour
{

    public Slider barrePdv;
    Animator animations;
    public string ennemi;
    public GameObject bamVFX;

    void Start()
    {
        animations = GetComponent<Animator>();
        //bamVFX = GameObject.Find("CFX_Hit").gameObject;
        bamVFX.SetActive(false);  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != ennemi)
        {
            return;
        }
        
       if(collision.transform.CompareTag("joueur"))
             if (collision.transform.GetComponentInParent<AttaquesDuJoueur>().enAttaque)
            {
                barrePdv.value -= 30;
                Debug.Log("J'attaque le zombie");
                if (bamVFX != null)
                {
                    bamVFX.SetActive(true);
                }
            }
        if (collision.transform.CompareTag("ennemi"))
            if (collision.transform.GetComponentInParent<EnnemiPoursuite>().attaqueZombie)
            {
                barrePdv.value -= 30;
                //Debug.Log("dégâts pris par le joueur");
                animations.SetBool("anim_repos", false);
                animations.SetBool("anim_marcher", false);
                animations.SetBool("anim_attaquer", false);
                if (bamVFX != null)
                {
                    animations.SetBool("anim_degatsRecus", true);
                }
            }

        if (barrePdv.value <= 0)
        {
            animations.SetBool("anim_mort", true);
            if (bamVFX != null)
            {
                animations.SetBool("anim_degatsRecus", false);
            }
    
            Destroy(bamVFX);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("ennemi"))
            if (collision.transform.GetComponentInParent<EnnemiPoursuite>().attaqueZombie)
            {
                if (bamVFX != null)
                {
                    animations.SetBool("anim_degatsRecus", false);
                    bamVFX.SetActive(false);
                }
            }
    }

}
