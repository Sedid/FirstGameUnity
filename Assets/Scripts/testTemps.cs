using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTemps : MonoBehaviour
{
    public testEchange testDeDiscussion;
    public float monTemps;
    public float tempsDernierDeclenchement = 0;
    private float tempsAttente = 3;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        monTemps = Time.time;
        if(monTemps - tempsDernierDeclenchement > tempsAttente)
        {
           // print("c'est bon, j'y suis");
            testDeDiscussion.oK = true;
            tempsDernierDeclenchement = Time.time;
        }
    }
}
