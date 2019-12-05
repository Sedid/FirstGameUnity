using UnityEngine;
using UnityEngine.UI;

public class DegatsRecus : MonoBehaviour
{

    public Slider barrePdv;
    Animator animations;
    public string ennemi;
    GameObject bamVFX;

    void Start()
    {
        animations = GetComponent<Animator>();
        bamVFX = GameObject.Find("CFX_Hit").gameObject;
        bamVFX.SetActive(false);  
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
            animations.SetBool("anim_degatsRecus", false);
            if (collision.transform.tag == "ennemi")
            {
                print("lancement de l'animation mort du joueur");
                FindObjectOfType<AudioManager>().Play("mortJoueur");
            }
            
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

}
