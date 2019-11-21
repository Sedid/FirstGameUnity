using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public bool obstacle = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            obstacle = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        obstacle = false;
    }

}
