using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DegatsRecus : MonoBehaviour
{

    //Singleton, instance unique d'une classe
    //Permet d'utiliser n'importe quel élément de cette classe dans une autre classe
    //Ici, on l'utilise pour appeler la fonction JoueurMort() dans le script RecuperationObjets
    public static DegatsRecus instance;

    public Slider barrePdv;
    public Slider vitaliteZombie;
    Animator animations;
    public string ennemi;
    public GameObject bamVFX;
    public GameObject tuEsMort;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        animations = GetComponent<Animator>();
        //bamVFX = GameObject.Find("CFX_Hit").gameObject;
        bamVFX.SetActive(false);
        tuEsMort.SetActive(false);
    }

    public void JoueurMort()
    {
        animations.SetBool("anim_mort", true);
        if (bamVFX != null)
        {
            animations.SetBool("anim_degatsRecus", false);
        }
        StartCoroutine(TuEsMort());
        Destroy(bamVFX);
    }

    public void ZombieMort()
    {
        animations.SetBool("zombie_mort", true);
        if (bamVFX != null)
        {
            animations.SetBool("anim_degatsRecus", false);
        }
        Destroy(bamVFX);
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
                vitaliteZombie.value -= 30;
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
            JoueurMort();
        }
        else if (vitaliteZombie.value <= 0)
        {
            ZombieMort();
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

    IEnumerator TuEsMort()
    {
        if (tuEsMort != null)
        {
            tuEsMort.SetActive(true);
            yield return new WaitForSeconds(5);
            Destroy(tuEsMort);
        }
    }
}
