using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperAnimator : MonoBehaviour
{
    //References
    Animator am;
    EnemyMovement pm;
    SpriteRenderer sr;
    Transform player;
    EnemyStats enemy;
    PlayerStats playerStats;

    public float attackDistance = 12f;
    public float attackCooldown = 1.0f;
    public float damageDelay = 0.5f; // Задержка перед нанесением урона

    private bool isAttacking = false;
    private float lastAttackTime = 0.0f;

    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<EnemyMovement>();
        sr = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<CirnoMovement>().transform;
        enemy = GetComponent<EnemyStats>();
        playerStats = FindObjectOfType<PlayerStats>();
        isAttacking = false;
    }

    void Update()
    {
        SpriteDirectionChecker();
        if (!isAttacking)
        {
            AttackPlayer();
        }
    }

    void SpriteDirectionChecker()
    {
        if (pm.lastHorizontalVector < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    void AttackPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < attackDistance)
        {
            if (Time.time - lastAttackTime > attackCooldown)
            {
                if (!isAttacking)
                {
                    StartCoroutine(AttackCoroutine());
                }
            }
        }
        else
        {
            isAttacking = false;
            am.SetBool("isAttacking", false);
        }
    }

    IEnumerator AttackCoroutine()
    {
        isAttacking = true;
        am.SetBool("isAttacking", true);

        yield return new WaitForSeconds(damageDelay);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < attackDistance + 0.2)
        {
            DealDamageToPlayer();
        }

        yield return new WaitForSeconds(am.GetCurrentAnimatorStateInfo(0).length - damageDelay); 

        lastAttackTime = Time.time;
        isAttacking = false;
        am.SetBool("isAttacking", false);
    }

    void DealDamageToPlayer()
    {        
        playerStats.TakeDamage(enemy.currentDamage * 2);
    }
}
