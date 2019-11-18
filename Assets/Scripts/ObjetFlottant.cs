using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetFlottant : MonoBehaviour

{
    public AnimationCurve myCurve;
   
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time / 4 % myCurve.length)), transform.position.z);
    }
}
