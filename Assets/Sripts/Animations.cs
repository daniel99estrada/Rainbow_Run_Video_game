using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo stateInfo;
    public bool animationEnded;

    void Start()
    {   
        animationEnded = false;

        animator = GetComponent<Animator>();
        animator.enabled = false;

        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    public void PlayAnimation(string AnimationName)
    {   
        animator.enabled = true;

        animator.Play(AnimationName);
        
        if(stateInfo.normalizedTime >= 1) 
        {
            animationEnded = true;
        }
    }

}
