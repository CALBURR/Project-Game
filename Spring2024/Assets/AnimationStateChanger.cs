using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    [SerializeField] private string currentState = "Idle";
    [SerializeField] bool animationsBlocked = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeAnimationState(string newState, float speed = 1){
        if(animationsBlocked){
            return;
        }

        animator.speed = speed;
        

        if(currentState == newState){
            return;
        }
        currentState = newState;
        animator.Play(currentState);

    }

    public void animationShouldBlock(string newState, float speed = 1){
        if(animationsBlocked){
            return;
        }
        ChangeAnimationState(newState, speed);
        animationsBlocked = true;
        // use co routine to wait a certain amount of time if I know how long just use that once time runs out set animationsBlocked to false
    }
}
