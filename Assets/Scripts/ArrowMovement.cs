using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed = 10f; // Okun hızı

    private void Start()
    {
        // Okun Rigidbody'sine ileri doğru hız uygula
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {   // Karakterin ön yönüne doğru yatay hareket
            if (gameObject.CompareTag("Arrow"))
            {
                rb.velocity = -transform.up * speed;
            }
            else
            {
                rb.velocity = transform.up * speed;
            }
        }
    }
}
