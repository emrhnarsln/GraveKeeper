using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 400f;
    EnemyStats boss;

    void Start()
    {
        boss = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss != null)
        {
            HealthBar.fillAmount = boss.health / MaxHealth;
        }
    }
    public void UpdateHealthBar(float CurrentHealth)
    {
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
