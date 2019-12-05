using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleportation : MonoBehaviour
{
    public Transform portailMap2;
    public Transform portailMap1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PortailEntree")
        {
            transform.position = portailMap2.position;
            FindObjectOfType<GestionSons>().Play("teleport");

            FindObjectOfType<GestionSons>().Play("ghostly");
        }
        if (other.gameObject.name == "PortailSortie")
        {
            transform.position = portailMap1.position;
            FindObjectOfType<GestionSons>().Play("teleport");
        }
    }
}
