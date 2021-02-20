using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private AnimatorOverrideController[] animatorOverrideControllers;

    private static readonly int IsWalking = Animator.StringToHash("isWalking");


    private void Start()
    {
        GameManager.Player.OnMovimentChanged += ChangeWheelAnimation;
        GameManager.Player.OnAbilitiesChanged += ChangeHeadAnimation;
        GameManager.Player.OnOnAbilitiesChanged();
    }

    private void ChangeWheelAnimation(bool isWalking, bool flipX)
    {
        playerAnimator.SetBool(IsWalking, isWalking);

        playerSpriteRenderer.flipX = flipX;
    }

    private void ChangeHeadAnimation(PlayerCondition condition)
    {
        print(condition);
        playerAnimator.runtimeAnimatorController = animatorOverrideControllers[(int) condition];
    }

    // Start is called before the first frame update
    private void UpdateAnimation()
    {
        // wheelAnimator.SetTrigger(ChangedItem);
    }
}