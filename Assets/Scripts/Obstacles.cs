using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public bool obstacle = false;
    JoueurMouvements joueurSpeed;

    private void Start()
    {
        joueurSpeed = gameObject.GetComponent<JoueurMouvements>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            obstacle = true;
        }
        if (collision.gameObject.name == "Portail")
        {
            Debug.Log("Collision avec le portail !");
            this.transform.position = new Vector3(2.9f, 26, 243.8f);
            if (this.transform.position == new Vector3(2.9f, 26, 243.8f))
            {
                this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                joueurSpeed.moveSpeed = 15f;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        obstacle = false;
    }

}
