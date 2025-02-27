using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemyRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale != 0)
        {
            if (player != null)
            {
                Vector3 lookDirection = (player.transform.position - transform.position).normalized;

                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                enemyRb.AddForce(lookDirection * speed);
                animator.SetFloat("speed", 1);
            }
            else
            {
                animator.SetFloat("speed", 0);
            }

        }
    }
}
