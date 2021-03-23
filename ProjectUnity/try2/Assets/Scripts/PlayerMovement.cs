using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gradesToRotate = 45;
    public float speed = 2;
    public Vector3 deltaMove;
    void Update()
    {

        //Defines movement in x,y location for character, it moves the character
        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        transform.Translate(deltaMove);

        //Define rotation when moving Left or Right
        deltaMove = new Vector3(0, Input.GetAxisRaw("Horizontal"), 0) * gradesToRotate * Time.deltaTime;
        transform.Rotate(deltaMove);
        if (Input.GetKey(KeyCode.E))
        {
            deltaMove = new Vector3(0,1, 0) * gradesToRotate * Time.deltaTime;
            transform.Rotate(deltaMove);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            deltaMove = new Vector3(0, -1, 0) * gradesToRotate * Time.deltaTime;
            transform.Rotate(deltaMove);
        }

    }
}
