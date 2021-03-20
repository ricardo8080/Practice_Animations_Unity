using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AniFacts //Data user needs to decide for each animation
{
    public bool neutral = true; 
    public string name; 
    public int end = 60; 
    public int nextAni = -1; 
    public float transitionSpeed = 0; 
}

public class BaseLayerAniCon : MonoBehaviour //Script that performs the heavylifting for playing our animations
{
    public static float aFrame = 1 / 30f; //How much time passes in a frame, if we assume a frame is 1/60th of a second
    public static float bFrame = 24 / 30f; //Frame rate adjusted from Blender
    public Animator aniConRef; 
    public int curentAnimation; 
    public float frame;
    public List<AniFacts> actions = new List<AniFacts>() { new AniFacts() }; 

    public void Start() //Sets default animation to idle and decides speed
    {
        Change(0,0); 
        aniConRef.enabled = false;
        Play(1); 
    }

    public void Change(int targetAniamtion = 0, float transitionSpeed = 0) //Command called to change which Animation is playing
    {
        curentAnimation = targetAniamtion; 
        if (transitionSpeed <= 0) aniConRef.PlayInFixedTime(actions[curentAnimation].name); 
        else aniConRef.CrossFadeInFixedTime(actions[curentAnimation].name, transitionSpeed); 
    }

    public bool Play(float rate) //Main method that runs/loops/triggers Animations
    {
        aniConRef.Update(rate * Time.deltaTime);
        var clipInfo = aniConRef.GetCurrentAnimatorClipInfo(0)[0];
        var frame = clipInfo.weight * (clipInfo.clip.length * clipInfo.clip.frameRate);

        bool over = actions[curentAnimation].nextAni < 0 && frame >= actions[curentAnimation].end; 
        if (over) 
        {
            int indexOLD = curentAnimation; 
            curentAnimation = actions[curentAnimation].nextAni; 
            Change(actions[indexOLD].nextAni, actions[indexOLD].transitionSpeed); 
        }
        return over;
    }
}