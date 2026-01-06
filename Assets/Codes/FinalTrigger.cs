using UnityEngine;

public class FinalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 1. Temas oldu mu?
        Debug.Log("BİR ŞEY ÇARPTI! Çarpanın adı: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            // 2. Çarpan şey Player mı?
            Debug.Log("Evet, çarpan PLAYER. UI Manager aranıyor...");

            // Level Kilidini Aç
            PlayerPrefs.SetInt("LevelReached", 3);
            PlayerPrefs.Save();

            // 3. UI Manager bulundu mu?
            GameUIManager uiManager = FindObjectOfType<GameUIManager>();

            if (uiManager != null)
            {
                Debug.Log("UI Manager BULUNDU! Panel açılıyor...");
                uiManager.ShowGameFinished();
            }
            else
            {
                Debug.LogError("HATA: Sahnede 'GameUIManager' scripti olan bir obje BULUNAMADI!");
            }
        }
        else
        {
            Debug.Log("Çarpan şey Player DEĞİL. Etiketi: " + other.tag);
        }
    }
}