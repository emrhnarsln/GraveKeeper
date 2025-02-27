using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private PlayerStats player;
    AudioManager audioManager;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if ((CompareTag("Arrow") || CompareTag("Axe") || CompareTag("Sword") || CompareTag("Spellshoot"))
            && other.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();


            if (enemy != null && player != null)
            {
                enemy.TakeDamage(player.attackPower);
                enemy.GetComponent<change_color>()?.OnDamage();
                audioManager.PlaySFX(audioManager.damage);
            }
        }

        if (CompareTag("Player") && (other.CompareTag("Enemy")))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            if (enemy != null && player != null)
            {
                enemy.Attack(player);
            }
        }
    }

}
