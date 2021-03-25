using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Transform camTarget;
    public float pLerp = .01f;
    public float rLerp = .02f;
    public Transform target;
    public GameObject playerToFollow;
    public static bool collision = false;
    public Vector3 previous_position;
    public Vector3 current_position;
    public Vector3 distance;

    private void Start()
    {
        //Get the player position
        previous_position = new Vector3( playerToFollow.transform.position.x
                                     , playerToFollow.transform.position.y, playerToFollow.transform.position.z);
    }

    void Update()
    {
        current_position = new Vector3(playerToFollow.transform.position.x
                                     , playerToFollow.transform.position.y, playerToFollow.transform.position.z);
        distance = new Vector3(current_position.x - previous_position.x
                              , current_position.y - previous_position.y, current_position.z - previous_position.z);
        previous_position = current_position;
        Vector3 direction = target.position - camTarget.transform.position;

        //Forces camera to follow the character
        //pLerp is the speed of movement for location
        //rLerp is the speed of movement for rotation 

        if (!collision)
        {
            transform.LookAt(target);
            transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
            transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
            camTarget.transform.position = new Vector3(camTarget.transform.position.x + distance.x
                                                   , camTarget.transform.position.y + distance.y, camTarget.transform.position.z + distance.z);
        }
    }

    public static bool getCollison()
    {
        return collision;
    }

    public static void setCollision(bool value)
    {
        collision = value;
    }

}
