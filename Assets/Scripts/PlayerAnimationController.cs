using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour{
    
    [SerializeField] private Animator characterAnimator;

    private void Start(){
        characterAnimator = transform.GetComponentInChildren<Animator>();
    }

    public void SetAnimationBool(string animationBoolName, bool isActive){
        characterAnimator.SetBool(animationBoolName, isActive);
    }
    
    
}