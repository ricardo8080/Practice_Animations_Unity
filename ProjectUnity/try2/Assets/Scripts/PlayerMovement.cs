using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gradesToRotate;
    public float speed;
    public float speedrotation ;
    public Vector3 deltaMove;
    public Transform camTarget;
    public Transform paladin;
    public GameObject player;
    private void Start()
    {
    }
    void Update()
    {
        //Defines movement in x,y location for character, it moves the character
        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        transform.Translate(deltaMove);

        //Define rotation when pressing E or Q
        if (Input.GetKey(KeyCode.E))
        {
            OrbitAround(1);
            deltaMove = new Vector3(0, 1, 0) * gradesToRotate * Time.deltaTime * speedrotation;
            transform.Rotate(deltaMove);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            OrbitAround(-1);
            deltaMove = new Vector3(0, -1, 0) * gradesToRotate * Time.deltaTime * speedrotation;
            transform.Rotate(deltaMove);
        }
    }

    private void OrbitAround(int xAxis)
    {
        if (xAxis > 0)
        camTarget.RotateAround(player.transform.position, Vector3.up, 1 );
        else if (xAxis < 0)
        camTarget.RotateAround(player.transform.position, Vector3.down, 1);
    }
}
