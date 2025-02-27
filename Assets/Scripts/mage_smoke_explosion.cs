using UnityEngine;

public class mage_smoke_explosion : MonoBehaviour
{
    public GameObject smallerBallPrefab; // Assign the smaller ball prefab in the inspector
    public int numberOfSmallerBalls = 6; // Number of smaller balls to instantiate
    public float explosionForce = 5f; // Force applied to the smaller balls
    public float maxDistance = 100f; // Merminin yok olacaðý maksimum mesafe
    private Vector3 spawnPosition;

    // Call this function to trigger the explosion

    void Start()
    {
        // Merminin yaratýldýðý konumu kaydet
        spawnPosition = transform.position;
    }

    void Update()
    {
        // Merminin baþlangýç konumundan uzaklýðýný kontrol et
        if (Vector3.Distance(spawnPosition, transform.position) > maxDistance)
        {

            Explode();
            Destroy(gameObject); // Belirtilen mesafeyi aþarsa yok et
        }
    }

    public void Explode()
    {
        float angleStep = 360f / numberOfSmallerBalls; // Equal angle step
        float angle = 0f; // Start angle

        for (int i = 0; i < numberOfSmallerBalls; i++)
        {
            // Calculate direction based on angle
            float directionX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float directionZ = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector3 direction = new Vector3(directionX, 0f, directionZ).normalized;

            // Instantiate a smaller ball
            GameObject smallerBall = Instantiate(smallerBallPrefab, transform.position, Quaternion.identity);

            // Get the Rigidbody component of the smaller ball
            Rigidbody rb = smallerBall.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Apply force in the calculated direction
                rb.AddForce(direction * explosionForce, ForceMode.Impulse);
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            }

            // Increment angle for the next ball
            angle += angleStep;
        }
    }
}