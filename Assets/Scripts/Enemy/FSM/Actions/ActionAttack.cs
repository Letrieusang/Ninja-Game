using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttack : FSMAction
{
    [Header("Config")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBtwAttacks;

    private EnemyBrain enemyBrain;
    private float timer;
    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        if (enemyBrain.Player == null) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            PlayerHealth playerHealth = enemyBrain.Player.GetComponent<PlayerHealth>();
            playerHealth?.TakeDamage(damage);
            timer = timeBtwAttacks;
        }
    }
}
