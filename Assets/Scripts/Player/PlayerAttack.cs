using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Weapon InitialWeapon;
    [SerializeField] private Transform[] attackPosition;
    
    private PlayerActions actions;
    private PlayerAnimations playerAnimations;
    private EnemyBrain enemyTarget;
    private Coroutine attackCoroutine;
    private PlayerMovement playerMovement;
    private PlayerMana playerMana;
    
    private Transform currentAttackPosition;
    private float currentAttackRotaion;
    private void Awake()
    {
        playerMana = GetComponent<PlayerMana>();
        actions = new PlayerActions();
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        actions.Attack.ClickAttack.performed += context => Attack();
    }

    private void Update()
    {
        GetFirePosition();
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
        if (currentAttackPosition != null)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAttackRotaion));
            Projectile projectile = Instantiate(InitialWeapon.ProjectilePrefab, currentAttackPosition.position, rotation);
            projectile.Direction = Vector3.up; 
            playerMana.UseMana(InitialWeapon.RequiredMana); 
        }
        
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

    private void GetFirePosition()
    {
        Vector2 moveDirection = playerMovement.MoveDirection;
        switch (moveDirection.x)
        {
            case > 0f:
                currentAttackPosition = attackPosition[1];
                currentAttackRotaion = -90f;
                break;
            case < 0f:
                currentAttackPosition = attackPosition[3];
                currentAttackRotaion = -270f;
                break;
        }

        switch (moveDirection.y)
        {
            case > 0f:
                currentAttackPosition = attackPosition[0];
                currentAttackRotaion = 0f;
                break;
            case < 0f:
                currentAttackPosition = attackPosition[2];
                currentAttackRotaion = -180f;
                break;
        }
    }
}
