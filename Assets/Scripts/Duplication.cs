using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Duplication : MonoBehaviour
{
    public Transform ObjetADupliquer;
    int compteur = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.V))
        {
           compteur++;
           Transform nouvelObjet = Instantiate(ObjetADupliquer);
           nouvelObjet.position = new Vector3(nouvelObjet.localScale.x * compteur, 0, 0) + ObjetADupliquer.position;
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            Transform nouvelObjet = Instantiate(ObjetADupliquer);
            float x = Random.Range(-5, 5);
            float y = Random.Range(0, 0);
            float z = Random.Range(-1, 1);
            nouvelObjet.position = new Vector3(x, y, z);
        }
    }
}
