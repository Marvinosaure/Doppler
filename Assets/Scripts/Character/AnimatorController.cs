using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _componentAnimator;

    private void Awake()
    {
        _componentAnimator = GetComponent<Animator>();    
    }    

    public void WalkAnimation()
    {
        _componentAnimator.SetBool("walk", true);
        _componentAnimator.SetBool("run", false);
    }

    public void RunAnimation()
    {
        _componentAnimator.SetBool("run", true);
        _componentAnimator.SetBool("walk", false);
    }

    public void JumpAnimation()
    {
        _componentAnimator.SetTrigger("jump");
    }

    public void IdleAnimation()
    {
        _componentAnimator.SetBool("walk", false);
        _componentAnimator.SetBool("run", false);
    }    
}
