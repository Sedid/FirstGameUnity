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
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            if (Mathf.Abs(Vector3.Angle(collision.contacts[0].normal, transform.forward)) > 90.0f)
            {
                obstacle = false;
            }
            else
                obstacle = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        obstacle = false;
    }

}
