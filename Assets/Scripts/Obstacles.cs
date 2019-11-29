using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public bool obstacle = false;
    JoueurMouvements joueurSpeed;
    Rigidbody rigidbodyJoueur;

    private void Start()
    {
        joueurSpeed = gameObject.GetComponent<JoueurMouvements>();
        rigidbodyJoueur = gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            obstacle = true;
        }
        //if (collision.gameObject.name == "Portail")
        //{
        //    Debug.Log("Collision avec le portail !");
        //    transform.position = new Vector3(4, 25.17f, 256);
        //    if (transform.position == new Vector3(4, 25.17f, 256))
        //    {
        //        transform.Rotate(0, -292.6f, 0.51f);
        //        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //        joueurSpeed.moveSpeed = 15f;
        //        joueurSpeed.turnSpeed = 25;
        //    }
        //}
        //if (collision.gameObject.name == "PortailSortie")
        //{
        //    Debug.Log("Collision avec le portail de sortie !");
        //    transform.position = new Vector3(3.682673f, 2.6985f, 5.914675f);
        //    if (transform.position == new Vector3(3.682673f, 2.6985f, 5.914675f))
        //    {
        //        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        //        transform.Rotate(0, -211.985f, 0);
        //        joueurSpeed.moveSpeed = .15f;
        //        joueurSpeed.turnSpeed = 75f;
        //        rigidbodyJoueur.constraints = RigidbodyConstraints.FreezeAll;
        //        rigidbodyJoueur.inertiaTensor = rigidbodyJoueur.inertiaTensor + new Vector3(0, 0, rigidbodyJoueur.inertiaTensor.z * 100);
        //    }
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        obstacle = false;
    }

}
