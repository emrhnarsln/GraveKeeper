using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyStats : MonoBehaviour
{
    public float health = 50f; // Düşmanın başlangıç sağlığı
    public float attackPower = 1f; // Düşmanın saldırı gücü
    private Animator animator;
    public float xpReward = 5;
    private Enemy enemy;
    private Timer time;
    private bool isStatsUpdated = false;
    AudioManager audioManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        time = FindObjectOfType<Timer>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        float mobSpawnTime = time.timeRemaining;
        UpdateStatsByTime(mobSpawnTime);
    }

    // Sağlık güncellemesi
    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, 400);
        FindObjectOfType<HealthSystem>().UpdateHealthBar(health);
        if (health <= 0)
        {
            Die();
        }
    }

    // Ölüm durumu
    private void Die()
    {
        GrantXP();
        enemy.speed = 0f;
        enemy.rotationSpeed = 0f;
        xpReward = 0f;
        animator.SetTrigger("Die");
        if (time.timeRemaining >= 60) // 60. saniyeden sonra çıkan düşman
        {
            GameManager.Instance.ShowVictoryScreen(FindObjectOfType<PlayerStats>().XP); // Victory ekranını aç
            audioManager.Victory();
        }
        Destroy(gameObject, 2f); // Düşmanı sahneden kaldır
    }

    // Saldırı
    public void Attack(PlayerStats player)
    {
        if (player != null)
        {
            player.TakeDamage(attackPower);
        }
    }
    private void GrantXP()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        if (player != null)
        {
            player.GainXP(xpReward);
        }
    }
    public void UpdateStatsByTime(float mobSpawnTime)
    {
        if (!isStatsUpdated)
        {
            if (mobSpawnTime >= 60)
            {
                isStatsUpdated = true;
                attackPower = 20;
                health = 400;
                xpReward = 50;
                enemy.speed = 8;
            }
            else if (mobSpawnTime <= 60 && mobSpawnTime > 45)
            {
                isStatsUpdated = true;
                attackPower = 16;
                enemy.speed = 5;
                xpReward = 50;
                health = 100;
            }
            else if (mobSpawnTime <= 45 && mobSpawnTime > 30)
            {
                isStatsUpdated = true;
                attackPower = 8;
                enemy.speed = 5;
                xpReward = 10;
            }
            else if (mobSpawnTime <= 30 && mobSpawnTime > 15)
            {
                isStatsUpdated = true;
                attackPower = 4;
            }
        }
    }
}
