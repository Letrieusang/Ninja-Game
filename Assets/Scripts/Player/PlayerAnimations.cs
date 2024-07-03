using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int MoveX = Animator.StringToHash("MoveX");
    private readonly int MoveY = Animator.StringToHash("MoveY");
    private readonly int Moving = Animator.StringToHash("Moving");
    private readonly int Dead = Animator.StringToHash("Dead");
    private readonly int Revive = Animator.StringToHash("Revive");
    private readonly int Attack = Animator.StringToHash("Attack");
    
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDeadAnimation()
    {
        animator.SetTrigger(Dead);
    }

    public void SetMoveBoolTransition(bool value)
    {
        animator.SetBool(Moving, value);
    }

    public void SetAttackAnimation(bool value)
    {
        animator.SetBool(Attack, value);
    }
    
    public void SetMoveAnimation(Vector2 dir)
    {
        animator.SetFloat(MoveX, dir.x);
        animator.SetFloat(MoveY, dir.y);
    }
    
    
    public void ResetPlayer()
    {
        SetMoveAnimation(Vector2.down);
        animator.SetTrigger(Revive);
    }
}

