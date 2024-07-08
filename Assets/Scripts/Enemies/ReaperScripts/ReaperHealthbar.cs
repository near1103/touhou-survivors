using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReaperHealthbar : MonoBehaviour
{
    [Header("UI")]
    public Image healthbar;

    EnemyStats enemy;
    void Start()
    {
        enemy = GetComponent<EnemyStats>();
    }

    void Update()
    {
        UpdateHealthBar();
    }
    void UpdateHealthBar() 
    {
        healthbar.fillAmount = enemy.currentHealth / enemy.enemyData.MaxHealth;
    }
}
