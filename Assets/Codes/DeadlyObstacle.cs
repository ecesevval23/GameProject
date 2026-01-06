using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadlyObstacle : MonoBehaviour
{
    // Çarpışma değil, "İçine Girme" olayını dinliyoruz
    private void OnTriggerEnter(Collider other)
    {
        // Çarpan şeyin etiketine bak
        if (other.CompareTag("Player"))
        {
            Debug.Log("YANDIN! Sahne Yenileniyor ve Puan Sıfırlanıyor...");

            // ESKİ KODUN: Sadece sahneyi yeniliyordu, puan kalıyordu.
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // YENİ KOD: GameManager üzerindeki reset fonksiyonunu çağırıyoruz.
            // Bu fonksiyon hem puanı 0 yapar hem de sahneyi yeniler.
            if (GameManager.Instance != null)
            {
                GameManager.Instance.RestartGame();
            }
            else
            {
                // Eğer sahnede GameManager yoksa (Test için) eski yöntem çalışsın
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}