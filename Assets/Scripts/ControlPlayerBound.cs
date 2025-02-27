using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlPlayerBound : MonoBehaviour
{
    public string targetSceneName = "FinalBossScene";
    private float bound = 45f;
    private Vector2 xBounds;
    private Vector2 zBounds;
    public Transform center; // Çemberin merkezi
    private float radius = 33f; // Çemberin yarıçapı

    void Start()
    {
        xBounds = new Vector2(-bound,bound); // X ekseni için sınırlar
        zBounds = new Vector2(-bound,bound); // Z ekseni için sınırlar
    }
    void Update()
    {
        // Karakterin mevcut pozisyonunu al
        Vector3 position = transform.position;
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (targetSceneName == currentSceneName)
        {
            if (position.magnitude > radius)
            {
                position = position.normalized * radius;
                transform.position = center.position + position;
            }
        }


        // X eksenindeki sınırları kontrol et
        position.x = Mathf.Clamp(position.x, xBounds.x, xBounds.y);

        // Z eksenindeki sınırları kontrol et
        position.z = Mathf.Clamp(position.z, zBounds.x, zBounds.y);

        // Güncellenmiş pozisyonu karaktere uygula
        transform.position = position;
    }
}
