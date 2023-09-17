using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator playerAnimator;
        private bool isJumping;
        private bool isFalling;
        private bool isWalking;
        private bool isIdle;

        private void Start()
        {
            playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            MoveAnimation();
        }

        public void MoveAnimation()
        {
            isWalking = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
            isJumping = Input.GetKeyDown(KeyCode.Space);
            isIdle = !isWalking && !isJumping && !isFalling;
            
            playerAnimator.SetBool(PlayerAnimatorFrag.IsJumping.ToString(),isJumping);
            playerAnimator.SetBool(PlayerAnimatorFrag.IsWalking.ToString(),isWalking);
            playerAnimator.SetBool(PlayerAnimatorFrag.IsFalling.ToString(),isFalling);
            playerAnimator.SetBool(PlayerAnimatorFrag.IsIdle.ToString(),isIdle);
        }
    }
    
    public enum PlayerAnimatorFrag
    {
        IsJumping,
        IsWalking,
        IsFalling,
        IsIdle,
    }
}