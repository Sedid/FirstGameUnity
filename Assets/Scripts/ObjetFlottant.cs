using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetFlottant : MonoBehaviour

{
    public AnimationCurve myCurve;
   
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time / 3.8f % myCurve.length)), transform.position.z);
    }
}
