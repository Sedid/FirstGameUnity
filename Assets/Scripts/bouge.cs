using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bouge : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 250f;
    public Animator anim;
    public Slider barrePdv;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Arrête la poursuite du joueur lorsque l'ennemi meurt
        if (barrePdv.value <= 0)
        {
            return;
        }
        // Déplacement du personnage
        if (Input.GetKey(KeyCode.UpArrow) && (!Input.GetKey(KeyCode.LeftShift)))
        {
            if (!GetComponent<Obstacles>().obstacle)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            if (!GetComponent<Obstacles>().obstacle)
            {
                transform.Translate(Vector3.forward * moveSpeed*2 * Time.deltaTime );
            }
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
                transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime / 2);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        // Animation walk lorsque fleches haut et bas sont appuyés
        if (Input.GetKey(KeyCode.UpArrow) && (!Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.DownArrow)))
        {
            anim.SetBool("anim_marcher", true);
            anim.SetBool("anim_repos", false);
            anim.SetBool("anim_courir", false);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftShift)))
        {
            anim.SetBool("anim_marcher", false);
            anim.SetBool("anim_repos", false);
            anim.SetBool("anim_courir", true);
        }
        else
        {
            anim.SetBool("anim_marcher", false);
            anim.SetBool("anim_repos", true);
            anim.SetBool("anim_courir", false);
        }
    }
}
