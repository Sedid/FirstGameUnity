using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleportation : MonoBehaviour
{
    public Transform portailMap2;
    public Transform portailMap1;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PortailEntree")
        {
            transform.position = portailMap2.position;
        }
        if (other.gameObject.name == "PortailSortie")
        {
            transform.position = portailMap1.position;
        }
    }
}
