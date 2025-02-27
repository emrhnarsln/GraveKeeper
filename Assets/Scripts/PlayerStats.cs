using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Oyuncu özellikleri
    public float health = 100;
    public float attackPower = 5;
    private Animator animator;
    public float XP = 0;

    private PlayerController player;
    private ArrowShooter arrowShooter;
    private Timer time;
    private bool isStatsUpdated = false;
    AudioManager audioManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        arrowShooter = GetComponent<ArrowShooter>();
        time = FindObjectOfType<Timer>();
        XP = PlayerPrefs.GetFloat("PlayerXP", 0);
        audioManager = FindFirstObjectByType<AudioManager>();
    }
    void OnDestroy()
    {
        PlayerPrefs.SetFloat("PlayerXP", XP);
        PlayerPrefs.Save();
    }
    void Update()
    {
        float gametime = time.timeRemaining;
        UpdateStatsByTime(gametime);
    }

    // Sağlık güncellemesi
    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, 100); // Sağlık 0 ile 100 arasında tutulur
        FindObjectOfType<HealthSystem>().UpdateHealthBar(health);

        if (health <= 0)
        {   
            arrowShooter.enabled = false;
            player.rotationSpeed = 0f;
            player.moveSpeed = 0;
            animator.SetBool("isShooting", false);
            animator.SetTrigger("Die");
            // Game Over ekranını gecikmeli çalıştır
            StartCoroutine(ShowGameOverWithDelay());
            // High Score kaydet
            float highScore = PlayerPrefs.GetFloat("HighScore", 0);
            if (XP > highScore)
            {
                PlayerPrefs.SetFloat("HighScore", XP);
                PlayerPrefs.Save();
            }
        }
    }
    private IEnumerator ShowGameOverWithDelay()
    {
        yield return new WaitForSeconds(2f); // 2 saniye bekle
        GameManager.Instance.ShowGameOverScreen(XP); // Game Over ekranını göster
        if(audioManager != null)
        {
            audioManager.GameOver();
        }
    }

    public void Heal(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, 100);
        FindObjectOfType<HealthSystem>().UpdateHealthBar(health);
    }

    // Güç artırma
    public void IncreaseAttackPower(float amount)
    {
        attackPower += amount;
    }

    // Hız güncellemesi
    public void IncreaseSpeed(float amount)
    {
        player.moveSpeed += amount;
    }

    public void GainXP(float amount)
    {
        XP += amount;
    }

    public void UpdateStatsByTime(float time)
    {
        if (!isStatsUpdated)
        {
            if (time >= 60)
            {
                isStatsUpdated = true;
                IncreaseAttackPower(15);
                Heal(100);
            }
            else if (time <= 60 && time > 45)
            {
                isStatsUpdated = true;
                IncreaseSpeed(3);
            }
            else if (time <= 45 && time > 30)
            {
                isStatsUpdated = true;
                Heal(25);
                IncreaseAttackPower(5);
            }
        }
    }
}
