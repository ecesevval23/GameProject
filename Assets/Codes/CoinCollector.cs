using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    void Update()
    {
        // Kendi etrafında dönme efekti
        transform.Rotate(0, 90f * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Yöneticiye ulaş ve puanı artır
            GameManager.Instance.AddScore(1);

            // Kendini yok et
            Destroy(gameObject);
        }
    }
}