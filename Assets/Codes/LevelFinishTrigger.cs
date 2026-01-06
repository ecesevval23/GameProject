using UnityEngine;

public class LevelFinishTrigger : MonoBehaviour
{
    // Oyuncu butona temas edince çalışır
    public int unlockLevelID = 2; // Açılacak yeni levelin indexi
    private void OnTriggerEnter(Collider other)
    {
        // Çarpan şey Oyuncu mu?
        if (other.CompareTag("Player"))
        {
            Debug.Log("Bölüm Bitti!");
            if (PlayerPrefs.GetInt("LevelReached") < unlockLevelID)
            {
                PlayerPrefs.SetInt("LevelReached", unlockLevelID);
                Debug.Log("Yeni seviye açıldı: " + unlockLevelID);
            }

            // Sahnedeki UI Yöneticisini bul ve paneli açtır
            GameUIManager uiManager = FindObjectOfType<GameUIManager>();

            if (uiManager != null)
            {
                uiManager.ShowLevelComplete();
            }
            else
            {
                Debug.LogError("HATA: Sahnede GameUIManager bulunamadı!");
            }



            // İstersen butonu bir daha basılmasın diye kapatabilirsin
            // gameObject.SetActive(false); 
        }
    }
}