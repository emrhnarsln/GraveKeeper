using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionSceneAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerController pc;
    private ArrowShooter arrowShooter;
    private HealthSystem healthSystem;
    private PlayerStats playerStats;

    public string targetSceneName = "SelectionScene";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pc = GetComponent<PlayerController>();
        arrowShooter = GetComponent<ArrowShooter>();
        healthSystem = GetComponent<HealthSystem>();
        playerStats = GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == targetSceneName)
        {
            animator.SetBool("isShooting", false);
            pc.enabled = false;
            arrowShooter.enabled = false;
            healthSystem.enabled = false;
            playerStats.enabled = false;
        }
        else
        {
            if (playerStats.health > 0)
            {
                animator.SetBool("isShooting", true);
                arrowShooter.enabled = true;
            }
            else
            {
                animator.SetBool("isShooting", false);
                arrowShooter.enabled = false;
            }
            pc.enabled = true;
            healthSystem.enabled = true;
            playerStats.enabled = true;
        }
    }

}
