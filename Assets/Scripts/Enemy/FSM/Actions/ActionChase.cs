using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChase : FSMAction
{
    [Header("Config")] [SerializeField] private float speed;

    private EnemyBrain enemyBrain;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        if (enemyBrain.Player == null) return;
        Vector3 dirtoPlayer = (enemyBrain.Player.position - transform.position);
        if (dirtoPlayer.magnitude >= 1.3f)
        {
            transform.Translate(dirtoPlayer.normalized * speed * Time.deltaTime);
        }
    }
}
