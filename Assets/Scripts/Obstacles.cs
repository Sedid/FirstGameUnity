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
            this.transform.position = new Vector3(4, 25.17f, 256);
            if (this.transform.position == new Vector3(4, 25.17f, 256))
            {
                this.transform.Rotate(0, -292.6f, 0.51f);
                this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                joueurSpeed.moveSpeed = 15f;
                joueurSpeed.turnSpeed = 10;
            }
        }
        if (collision.gameObject.name == "PortailSortie")
        {
            Debug.Log("Collision avec le portail de sortie !");
            this.transform.position = new Vector3(3.92f, 2.6985f, 5.55f);
            if (this.transform.position == new Vector3(3.92f, 2.6985f, 5.55f))
            {
                this.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                this.transform.Rotate(0, -350.127f, 0);
                joueurSpeed.moveSpeed = .15f;
                joueurSpeed.turnSpeed = 75f;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        obstacle = false;
    }

}
