using System.Collections;
using UnityEngine;

public class change_color : MonoBehaviour
{
    private SkinnedMeshRenderer[] skinnedMeshRenderers; // Array to hold all SkinnedMeshRenderers
    private Color[] originalColors;                    // Array to store the original colors of each material
    public float feedbackDuration = 0.2f;              // Duration for the color change

    private void Start()
    {
        // Get all SkinnedMeshRenderer components in the GameObject and its children
        skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        if (skinnedMeshRenderers.Length == 0)
        {
            Debug.LogError("No SkinnedMeshRenderer components found in this prefab!");
            return;
        }

        // Store the original colors of all materials
        originalColors = new Color[skinnedMeshRenderers.Length];
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            if (skinnedMeshRenderers[i].material.HasProperty("_Color"))
            {
                originalColors[i] = skinnedMeshRenderers[i].material.color;
            }
            else
            {
                Debug.LogWarning($"Material on {skinnedMeshRenderers[i].gameObject.name} does not have a _Color property.");
                originalColors[i] = Color.white; // Default to white if no _Color property exists
            }
        }
    }

    public void OnDamage()
    {
        // Trigger the color change
        StartCoroutine(DamageFeedbackCoroutine());
    }

    private IEnumerator DamageFeedbackCoroutine()
    {
        // Choose a random damage color (red or orange)
        Color damageColor = Random.value > 0.5f ? Color.red : new Color(1f, 0.5f, 0f);

        // Change the color of all SkinnedMeshRenderers to the damage color
        foreach (var renderer in skinnedMeshRenderers)
        {
            if (renderer.material.HasProperty("_Color"))
            {
                renderer.material.color = damageColor;
            }
        }

        // Wait for the feedback duration
        yield return new WaitForSeconds(feedbackDuration);

        // Revert the colors of all SkinnedMeshRenderers back to their original colors
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            if (skinnedMeshRenderers[i].material.HasProperty("_Color"))
            {
                skinnedMeshRenderers[i].material.color = originalColors[i];
            }
        }
    }
}
