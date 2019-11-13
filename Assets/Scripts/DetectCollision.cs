using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {/*
        print("j'ai collisionné un truc");
        print(collision.gameObject.name);
        */
        if(collision.gameObject.name == "Ennemi")
        {
            print("Touché, Aaargh !");
        }
        if(collision.gameObject.tag == "ennemi")
        {
            print("Olala, j'ai touché un ennemi");
        }
        for(int i=1;i<5;i++)
        {
            if (collision.gameObject.tag == "ennemi")
            {
                print("j'ai touché un ennemi" + i.ToString() + "fois");
            }
        }
    }
}
