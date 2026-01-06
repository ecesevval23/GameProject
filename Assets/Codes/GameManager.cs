using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int totalScore = 0;

    // Ses durumu için değişken
    private bool isMuted = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Puan Ekleme
    public void AddScore(int amount)
    {
        totalScore += amount;
        Debug.Log("Puan: " + totalScore);
    }


    // Oyunu Durdur / Devam Ettir (Zamanı dondurur)
    public void PauseGame(bool status)
    {
        // status true ise durdur (zaman 0), false ise devam et (zaman 1)
        Time.timeScale = status ? 0 : 1;
    }

    // Ses Aç / Kapa
    public void ToggleAudio()
    {
        isMuted = !isMuted;
        // AudioListener sahnedeki tüm sesleri kontrol eder
        AudioListener.volume = isMuted ? 0 : 1;
    }

    // Sahne Yükleme
    public void LoadLevel(string sceneName)
    {
        totalScore = 0; // Puanı sıfırla ki yeni bölümde 0'dan başlasın
        Debug.Log("Puan Sıfırlandı!");
        Time.timeScale = 1; // Sahne değişirse zamanı normale döndür
        SceneManager.LoadScene(sceneName);
    }

    // Oyunu Baştan Başlat
    public void RestartGame()
    {
        totalScore = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}