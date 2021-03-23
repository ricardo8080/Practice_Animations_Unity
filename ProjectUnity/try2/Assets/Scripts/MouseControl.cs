using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 2;
    public GameObject mover;
    public Transform target;
    private void Start()
    {
        //Locks Mouse to Monitor, it dissapears
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        
        //Limits of screen movement
        /*
        if (turn.x > 25) turn.x = 25;
        else if (turn.x < -25) turn.x = -25;
        if (turn.y > 15) turn.y = 15;
        else if (turn.y < -20) turn.y = -20;
        transform.LookAt(target);
        */
        mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0); //Moves CameraHolder from left to right
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);      //Moves mainCamera from up to down
         deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
    }
}
