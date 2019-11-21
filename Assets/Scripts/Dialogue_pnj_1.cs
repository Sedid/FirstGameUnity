using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_pnj_1 : MonoBehaviour
{
    public GameObject dialogue;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pnj"))
        {
            dialogue.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("pnj"))
        {
            dialogue.SetActive(false);
        }
    }
}

