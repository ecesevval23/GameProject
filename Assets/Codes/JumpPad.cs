using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Header("Trambolin Ayarı")]
    public float force = 25f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.BouncePlayer(force);
                Debug.Log("UÇUŞ BAŞLADI!");
            }
        }
    }
}