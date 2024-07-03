using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerActions actions;
    private PlayerAnimations playerAnimations;
    private EnemyBrain enemyTarget;
    private Coroutine attackCoroutine;

    private void Start()
    {
        actions.Attack.ClickAttack.performed += context => Attack();
    }

    private void Attack()
    {
        if (enemyTarget == null) return;
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        attackCoroutine = StartCoroutine(IEAttack());

    }

    private IEnumerator IEAttack()
    {
        playerAnimations.SetAttackAnimation(true);
        yield return new WaitForSeconds(0.5f);
        playerAnimations.SetAttackAnimation(false);
    }

    private void EnemmySelectedCallback(EnemyBrain enemySelected)
    {
        enemyTarget = enemySelected;
    }

    private void NoEnemySelectedCallback()
    {
        enemyTarget = null;
    }
    private void Awake()
    {
        actions = new PlayerActions();
        playerAnimations = GetComponent<PlayerAnimations>();
        
    }

    private void OnEnable()
    {
        actions.Enable();
        SelectionManager.OnEnemySelectedEvent += EnemmySelectedCallback;
        SelectionManager.OnNoSelectionEvent += NoEnemySelectedCallback;
    }

    private void OnDisable()
    {
        actions.Disable();    
        SelectionManager.OnEnemySelectedEvent -= EnemmySelectedCallback;
        SelectionManager.OnNoSelectionEvent -= NoEnemySelectedCallback;
    }
}
