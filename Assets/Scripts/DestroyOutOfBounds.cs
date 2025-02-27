using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float maxDistance = 100f; // Merminin yok olacağı maksimum mesafe
    private Vector3 spawnPosition;

    void Start()
    {
        // Merminin yaratıldığı konumu kaydet
        spawnPosition = transform.position;
    }

    void Update()
    {
        // Merminin başlangıç konumundan uzaklığını kontrol et
        if (Vector3.Distance(spawnPosition, transform.position) > maxDistance)
        {
            Destroy(gameObject); // Belirtilen mesafeyi aşarsa yok et
        }
    }
}
