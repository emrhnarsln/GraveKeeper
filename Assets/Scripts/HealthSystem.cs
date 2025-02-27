using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthSystem : MonoBehaviour
{
    public Image HealthBar;
    public Image XPBar;
    public float CurrentHealth;
    public float CurrentXP;
    private float MaxHealth = 100f;
    private float MaxXP = 200f;
    PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player !=null)
        {
            HealthBar.fillAmount = player.health / MaxHealth;
            XPBar.fillAmount = player.XP / MaxXP;
        }
    }
    public void UpdateHealthBar(float CurrentHealth)
    {
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }

    public void UpdateXPBar(float CurrentXP)
    {
        XPBar.fillAmount = CurrentXP / MaxXP;
    }
}
