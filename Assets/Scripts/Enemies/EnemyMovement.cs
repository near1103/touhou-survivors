using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;

    EnemyStats enemy;

    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<CirnoMovement>().transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);    //Constantly move the enemy towards the player
        InputManagement();
    }

    void InputManagement()
    {
        moveDir = (player.position - transform.position).normalized;
        lastHorizontalVector = moveDir.x;
        lastVerticalVector = moveDir.y;
    }
}
