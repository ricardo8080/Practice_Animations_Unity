using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialExample : MonoBehaviour
{
    public BaseLayerAniCon aniCon;
    public GameObject character;
    public float yTarget;
    public float wTarget;
    private void Start()
    {
        aniCon.Start();
    }

    void Update()
    {
        aniCon.Play(1);

        if (aniCon.actions[aniCon.curentAnimation].neutral) //If Current Animation = A neutral action
        {
            if (Input.GetKeyDown(KeyCode.Y)) //If you press y do this aniamtion
            {
                aniCon.Change(2, .4f);
            }
            else if (Input.GetKey(KeyCode.UpArrow)) //If you press Up Arrow, Activate walking forward
            {
                if (aniCon.curentAnimation != 1) aniCon.Change(1, .3f);
                yTarget = Mathf.MoveTowards(yTarget, 1, .05f);
            }
            else //Otherwise, return to idle
            {
                if (aniCon.curentAnimation != 0) aniCon.Change(0, .4f);
                yTarget = Mathf.MoveTowards(yTarget, 0, .05f);
                character.transform.eulerAngles = new Vector3(
                        0,
                        0,
                        0);
            }
        }

        aniCon.aniConRef.SetFloat("y", yTarget);
    }
}