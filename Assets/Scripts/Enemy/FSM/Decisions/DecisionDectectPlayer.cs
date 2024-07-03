using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionDectectPlayer : FSMDecision
{
    [Header("Config")]
    [SerializeField] private float detectRange;
    [SerializeField] private LayerMask playerMask;
    private EnemyBrain enemyBrain;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    public override bool Decide()
    {
        return DetectPlayer();
    }

    private bool DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(enemyBrain.transform.position, detectRange, playerMask);
        if (playerCollider != null)
        {
            enemyBrain.Player = playerCollider.transform;
            Debug.Log("Player Detected");
            return true;
        }

        enemyBrain.Player = null; 
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
