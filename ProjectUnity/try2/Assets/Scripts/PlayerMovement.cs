using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public Vector3 deltaMove;
    void Update()
    {
        //Defines movement in x,y location for character, it moves the character
        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        transform.Translate(deltaMove);
    }
}
