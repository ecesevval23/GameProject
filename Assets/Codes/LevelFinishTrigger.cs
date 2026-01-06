using UnityEngine;

public class LevelFinishTrigger : MonoBehaviour
{
    public int unlockLevelID = 2; // Açılacak yeni level
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Bölüm Bitti!");
            if (PlayerPrefs.GetInt("LevelReached") < unlockLevelID)
            {
                PlayerPrefs.SetInt("LevelReached", unlockLevelID);
                Debug.Log("Yeni seviye açıldı: " + unlockLevelID);
            }

            GameUIManager uiManager = FindObjectOfType<GameUIManager>();

            if (uiManager != null)
            {
                uiManager.ShowLevelComplete();
            }
            else
            {
                Debug.LogError("HATA: Sahnede GameUIManager bulunamadı!");
            }

        }
    }
}