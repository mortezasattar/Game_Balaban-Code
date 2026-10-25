using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public static AnimationController instance;
    public Animator animator;

    private void Awake()
    {
        instance = instance != null ? instance : this;
    }


    public void PlayAnimation(string animationName,bool isbolean)
    {
        if(isbolean == false)
            animator.SetTrigger(animationName);
        else
            animator.SetBool(animationName, isbolean);
    }

    public void ResetAnimator()
    {
        animator.Rebind();
    }

    private void OnDisable()
    {
        animator = null;
    }
}
