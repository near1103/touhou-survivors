using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperMoveSpeedChanger : MonoBehaviour
{
    EnemyStats enemy;
    PlayerStats player;
    float startTime;
    public float speedIncreaseRate = 0.09f; // Скорость увеличения

    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<PlayerStats>();
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

       
        float targetSpeed = player.CurrentMoveSpeed * 0.75f;
        float newSpeed = Mathf.Lerp(enemy.enemyData.MoveSpeed, targetSpeed, elapsedTime * speedIncreaseRate);
        enemy.currentMoveSpeed = newSpeed;

        enemy.currentMoveSpeed = Mathf.Min(enemy.currentMoveSpeed, targetSpeed);
    }
}