using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Transform camTarget;
    public float pLerp = .01f;
    public float rLerp = .02f;
    public Transform target;

    void Update()
    {
        transform.LookAt(target);
        //Forces camera to follow the character
        //pLerp is the speed of movement for location
        //rLerp is the speed of movement for rotation 
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
   }
}
