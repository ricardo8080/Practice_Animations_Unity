using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rbdSkeleton;
    private Animator animator;

    public float range = 5;
    private void Start()
    {
        rbdSkeleton = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //RaycastHit hit;
        /*Vector3 direction = transform.position + charCtrl.center;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));*/
        //float distanceToObstacle = 0;
        /*
        if (Physics.SphereCast(direction, charCtrl.height / 2, transform.forward, out hit, 3))
        {
            distanceToObstacle = hit.distance;
            if (hit.collider.tag == "Player")
            {
                print("It's the ENEMY!!!!!");
            }
        }
        
        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "wall")
            {
                print("It's the Environment-");
            }
            else if (hit.collider.tag == "Player")
            {
            }
        }
        */


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
        }
    }
}
