using UnityEngine;
using UnityEngine.UI;
public class EnnemiPoursuite : MonoBehaviour
{
    static Animator animationsEnnemi;
    public Transform joueur;
    public Slider barrePdv;
    public Slider barrePdvJoueur;
    public bool attaqueZombie = false;
    float tempsDAttaque = 1f;
    readonly float tempsDebutAttaque = 0;
    GameObject zombieWalk;
    GameObject zombieAttack;
    GameObject playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        animationsEnnemi = GetComponent<Animator>();
        zombieWalk = GameObject.Find("zombieWalk").gameObject;
        zombieWalk.SetActive(false);
        zombieAttack = GameObject.Find("zombieAttack").gameObject;
        zombieAttack.SetActive(false);
        playerDeath = GameObject.Find("playerDeath").gameObject;
        playerDeath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - tempsDebutAttaque > tempsDAttaque)
        {
            attaqueZombie = false;
        }
        // Arrête la poursuite du joueur lorsque l'ennemi meurt
        if (barrePdv.value <= 0)
        {
            zombieAttack.SetActive(false);
            // fait disparaître l'ennemi
            Destroy(this.transform.gameObject, 5);
            return;
        }

        // orientation du joueur vers l'ennemi, ligne directe entre l'ennemi et le joueur
        Vector3 orientation = joueur.position - this.transform.position;

        float champVision = Vector3.Angle(orientation, this.transform.forward);

        if (Vector3.Distance(joueur.position, this.transform.position) < 2 && champVision < 120)
        {

            // On désactive l'animation de repos de l'ennemi lorsqu'il est assez proche du joueur pour le poursuivre
            animationsEnnemi.SetBool("anim_repos", false);

            // Si la longueur du vecteur est supérieur à 0.035, on dirige l'ennemi vers le joueur uniquement via l'axe Z, de 0.0025 de distance à chaque "pas" (avancée) de l'ennemi 
            if (orientation.magnitude > .035f)
            {
                animationsEnnemi.SetBool("anim_attaquer", false);
                animationsEnnemi.SetBool("anim_marcher", true);
                this.transform.Translate(0, 0, .0010f);
                zombieWalk.SetActive(true);
                zombieAttack.SetActive(false);
            }
            else if (barrePdvJoueur.value <= 0)
            {
                attaqueZombie = false;
                animationsEnnemi.SetBool("anim_attaquer", false);
                animationsEnnemi.SetBool("anim_repos", true);
                zombieAttack.SetActive(false);
                zombieWalk.SetActive(false);
                playerDeath.SetActive(true);
            }
            else if (barrePdvJoueur.value > 0)
            {
                animationsEnnemi.SetBool("anim_marcher", false);
                attaqueZombie = true;
                tempsDAttaque = Time.time;
                animationsEnnemi.SetBool("anim_attaquer", true);
                zombieAttack.SetActive(true);
                zombieWalk.SetActive(false);
                playerDeath.SetActive(false);
            }
            else 
            {
                attaqueZombie = false;
                animationsEnnemi.SetBool("anim_attaquer", false);
                animationsEnnemi.SetBool("anim_repos", true);
                zombieWalk.SetActive(false);
                zombieAttack.SetActive(false);
                playerDeath.SetActive(false);
            }

            // différence de taille entre le joueur et l'ennemi supprimé, 
            // pour éviter que l'ennemi ou le joueur ne tombe à terre lorsqu'il y a une collision
            orientation.y = 0; 

            // fait pivoter l'ennemi vers le joueur grâce à la direction récupérée précédemment
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(orientation), .1f);   
        }

        else
        {
            animationsEnnemi.SetBool("anim_repos", true);
            animationsEnnemi.SetBool("anim_marcher", false);
            animationsEnnemi.SetBool("anim_attaquer", false);
            zombieWalk.SetActive(false);
            zombieAttack.SetActive(false);
        }
    }
}
