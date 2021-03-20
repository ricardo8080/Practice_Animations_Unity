using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Transform camTarget;
    public float pLerp = .1f;
    public float rLerp = .2f;

    void Update()
    {
        //Forces camera to follow the character
        //pLerp is the speed of movement for location
        //rLerp is the speed of movement for rotation 
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
   }
}
