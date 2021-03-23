using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAOpen : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().SetTrigger("DoorATrigger");
        //GetComponent<Animator>().SetTrigger("DoorATrigger");
    }
}