using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public GameObject arrowPrefab;  // Ok prefabı
    public Transform firePoint;    // Okun fırlatılacağı nokta
    public float fireInterval = 1f; // Fırlatma aralığı (saniye)
    public Vector3 positionOffset; // Pozisyon ofseti


    private void Start()
    {
        StartCoroutine(FireArrows());
    }

    private IEnumerator FireArrows()
    {
        while (true)
        {
            FireArrow();


            yield return new WaitForSeconds(fireInterval);
        }
    }

    private void FireArrow()
    {
        if (arrowPrefab != null && firePoint != null)
        {
            Quaternion rotation;
            Vector3 position;
            if (arrowPrefab.CompareTag("Arrow"))
            {
                positionOffset = new Vector3(0f, 1.20f, 1.5f);
                rotation = firePoint.rotation * Quaternion.Euler(0, -90, 90);
                position = firePoint.position + firePoint.TransformDirection(positionOffset);
                Instantiate(arrowPrefab, position, rotation);

                positionOffset = new Vector3(0f, 1.20f, 1.5f);
                rotation = firePoint.rotation * Quaternion.Euler(0, -120, 90);
                position = firePoint.position + firePoint.TransformDirection(positionOffset);
                Instantiate(arrowPrefab, position, rotation);

                positionOffset = new Vector3(0f, 1.20f, 1.5f);
                rotation = firePoint.rotation * Quaternion.Euler(0, -60, 90);
                position = firePoint.position + firePoint.TransformDirection(positionOffset);
                Instantiate(arrowPrefab, position, rotation);
            }
            else if (arrowPrefab.CompareTag("Axe"))
            {
                positionOffset = new Vector3(1f, 1f, 1.5f);
                rotation = firePoint.rotation * Quaternion.Euler(0, -90, -90);
                position = firePoint.position + firePoint.TransformDirection(positionOffset);
                Instantiate(arrowPrefab, position, rotation);

            }
            else if (arrowPrefab.CompareTag("Sword"))
            {
                // FirePoint'in baktığı yönde
                positionOffset = new Vector3(0f, 1f, 2f);
                rotation = firePoint.rotation * Quaternion.Euler(0, -90, -90);
                position = firePoint.position + firePoint.TransformDirection(positionOffset);
                Instantiate(arrowPrefab, position, rotation);

                // FirePoint'in sağında
                positionOffset = new Vector3(2f, 1f, 0f);
                rotation = firePoint.rotation * Quaternion.Euler(0, 0, -90); // Rotasyonu sağa çevir
                position = firePoint.position + firePoint.TransformDirection(positionOffset);
                Instantiate(arrowPrefab, position, rotation);

                // FirePoint'in solunda
                positionOffset = new Vector3(-2f, 1f, 0f);
                rotation = firePoint.rotation * Quaternion.Euler(0, 0, 90); // Rotasyonu sola çevir
                position = firePoint.position + firePoint.TransformDirection(positionOffset);
                Instantiate(arrowPrefab, position, rotation);

                // FirePoint'in arkasında
                positionOffset = new Vector3(0f, 1f, -2f);
                rotation = firePoint.rotation * Quaternion.Euler(0, 90, -90); // Rotasyonu arkaya çevir
                position = firePoint.position + firePoint.TransformDirection(positionOffset);
                Instantiate(arrowPrefab, position, rotation);

            }
            else
            {
                positionOffset = new Vector3(0f, 1f, 1f);
                rotation = firePoint.rotation * Quaternion.Euler(0, -90, -90);
                position = firePoint.position + firePoint.TransformDirection(positionOffset);
                Instantiate(arrowPrefab, position, rotation);
            }
        }
    }

}
