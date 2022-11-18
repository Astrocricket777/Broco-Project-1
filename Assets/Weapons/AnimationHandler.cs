using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator TheAnimator;

    void Update()
    {
        WalkCheck();
        FireCheck();
    }

    public void WalkCheck()
    {
        if (Input.GetKey(KeyCode.W))
        {
            TheAnimator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            TheAnimator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            TheAnimator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            TheAnimator.SetBool("IsWalking", true);
        }
        else
        {
            TheAnimator.SetBool("IsWalking", false);
        }
    }

    public void FireCheck()
    {
        if (Input.GetMouseButton(0))
        {
            TheAnimator.SetBool("IsFiring", true);
        }
        else
        {
            TheAnimator.SetBool("IsFiring", false);
        }
    }
}
