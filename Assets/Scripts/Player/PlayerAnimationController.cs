using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator wheelAnimator;
    [SerializeField] private GameObject jumpObject;

    [SerializeField] private Transform headSpriteRenderer;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsWalkingRight = Animator.StringToHash("isWalkingRight");
    private static readonly int ChangedItem = Animator.StringToHash("changedItem");
    private static readonly int HasRight = Animator.StringToHash("hasRight");
    private static readonly int HasLeft = Animator.StringToHash("hasLeft");


    private void Start()
    {
        GameManager.Player.OnMovimentChanged += ChangeWheelAnimation;
        GameManager.Player.OnAbilitiesChanged += ChangeHeadAnimation;
        ChangeHeadAnimation(GameManager.Player.hasLeft, GameManager.Player.hasRight, 
            GameManager.Player.hasJump, GameManager.Player.hasDown);
    }

    private void ChangeWheelAnimation(bool isWalking, bool isMovingRight, bool flipX)
    {
        wheelAnimator.SetBool(IsWalking, isWalking);
        wheelAnimator.SetBool(IsWalkingRight, isMovingRight);
        if (flipX)
            headSpriteRenderer.Rotate(new Vector3(0,180,0));
        UpdateAnimation();
    }
    
    private void ChangeHeadAnimation(bool hasLeft, bool hasRight, bool hasJump, bool hasDown)
    {
        wheelAnimator.SetBool(HasLeft, hasLeft);
        wheelAnimator.SetBool(HasRight, hasRight);

        jumpObject.SetActive(hasJump);
    }

    // Start is called before the first frame update
    private void UpdateAnimation()
    {
        wheelAnimator.SetTrigger(ChangedItem);
    }
}
