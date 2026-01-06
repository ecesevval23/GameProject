using UnityEngine;

public class FinalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("LevelReached", 3);
            PlayerPrefs.Save();

            GameUIManager uiManager = FindObjectOfType<GameUIManager>();

            if (uiManager != null)
            {
                uiManager.ShowGameFinished();
            }
            else
            {
                Debug.LogError("HATA: Sahnede 'GameUIManager' scripti olan bir obje BULUNAMADI!");
            }
        }

    }
}