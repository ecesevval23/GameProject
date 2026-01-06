using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 0.5f;
    public float respawnDelay = 3f;

    private MeshRenderer meshRenderer;
    private Collider col;
    private Vector3 originalPos;
    private bool isFalling = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
        originalPos = transform.position;
    }
    public void StartFalling()
    {
        if (!isFalling)
        {
            StartCoroutine(FallRoutine());
        }
    }

    IEnumerator FallRoutine()
    {
        isFalling = true;

        // Biraz bekle (Oyuncu fark etsin)
        yield return new WaitForSeconds(fallDelay);

        meshRenderer.enabled = false;
        col.enabled = false;

        if (respawnDelay > 0)
        {
            yield return new WaitForSeconds(respawnDelay);
            transform.position = originalPos;
            meshRenderer.enabled = true;
            col.enabled = true;
            isFalling = false;
        }
    }
}