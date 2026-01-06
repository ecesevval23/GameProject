using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Header("Trambolin Ayarı")]
    public float ziplamaGucu = 25f; // Bu sayıyı artırırsan daha yükseğe uçar

    private void OnTriggerEnter(Collider other)
    {
        // Çarpan şeyin Player olup olmadığına bakıyoruz
        if (other.CompareTag("Player"))
        {
            // PlayerController scriptine ulaşıyoruz
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                // Az önce eklediğimiz fonksiyonu çalıştırıyoruz
                player.BouncePlayer(ziplamaGucu);
                Debug.Log("UÇUŞ BAŞLADI!");
            }
        }
    }
}