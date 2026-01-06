using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 0.5f; // Bekleme süresi
    public float respawnDelay = 3f; // Geri gelme süresi

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

    // Bu fonksiyonu PlayerController çağıracak (Public olması şart)
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

        // Platformu kapat (Yok etme, sadece görünmez ve dokunulmaz yap)
        meshRenderer.enabled = false;
        col.enabled = false;

        // Geri gelme mantığı
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