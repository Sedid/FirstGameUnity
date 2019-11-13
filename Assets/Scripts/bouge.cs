using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bouge : MonoBehaviour
{
    public float vitesse = 0.5f;
    public Slider barrePdv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Arrête la poursuite du joueur lorsque l'ennemi meurt
        if (barrePdv.value <= 0)
        {
            return;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, vitesse*4, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -vitesse*4, 0);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, vitesse/5);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -vitesse/5);
        }
    }
}
