using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int totalScore = 0;
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
    public void AddScore(int amount)
    {
        totalScore += amount;
        Debug.Log("Puan: " + totalScore);
    }
    public void PauseGame(bool status)
    {
        // status true ise durdur, false ise devam et
        Time.timeScale = status ? 0 : 1;
    }
    public void ToggleAudio()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;
    }
    public void LoadLevel(string sceneName)
    {
        totalScore = 0;
        Debug.Log("Puan Sıfırlandı!");
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
    public void RestartGame()
    {
        totalScore = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}