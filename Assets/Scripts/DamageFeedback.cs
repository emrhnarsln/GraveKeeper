using System.Collections;
using UnityEngine;

public class DamageFeedback : MonoBehaviour
{
    // Reference to the SpriteRenderer of the enemy
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    // Duration for the color change
    public float feedbackDuration = 0.2f;

    private void Start()
    {
        // Get the SpriteRenderer component of the enemy
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the enemy GameObject.");
            return;
        }

        // Store the original color
        originalColor = spriteRenderer.color;
    }

    public void OnDamage()
    {
        // Trigger the color change
        if (spriteRenderer != null)
        {
            StartCoroutine(DamageFeedbackCoroutine());
        }
    }

    private IEnumerator DamageFeedbackCoroutine()
    {
        // Choose a random color (red or orange)
        Color damageColor = Random.value > 0.5f ? Color.red : new Color(1f, 0.5f, 0f); // Orange color

        // Set the enemy color to the damage color
        spriteRenderer.color = damageColor;

        // Wait for the feedback duration
        yield return new WaitForSeconds(feedbackDuration);

        // Revert back to the original color
        spriteRenderer.color = originalColor;
    }
}
