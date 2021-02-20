using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");


    private void Start()
    {
        GameManager.Player.OnMovimentChanged += ChangeWheelAnimation;
        GameManager.Player.OnAbilitiesChanged += ChangeHeadAnimation;
        ChangeHeadAnimation(GameManager.Player.hasLeft, GameManager.Player.hasRight,
            GameManager.Player.hasJump, GameManager.Player.hasDown);
    }

    private void ChangeWheelAnimation(bool isWalking, bool flipX)
    {
        playerAnimator.SetBool(IsWalking, isWalking);

        playerSpriteRenderer.flipX = flipX;
    }

    private void ChangeHeadAnimation(bool hasLeft, bool hasRight, bool hasJump, bool hasDown)
    {
        // wheelAnimator.SetBool(HasLeft, hasLeft);
        // wheelAnimator.SetBool(HasRight, hasRight);
        //
        // jumpObject.SetActive(hasJump);
    }

    // Start is called before the first frame update
    private void UpdateAnimation()
    {
        // wheelAnimator.SetTrigger(ChangedItem);
    }
}