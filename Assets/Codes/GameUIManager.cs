using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject pausePanel;
    public GameObject levelCompletePanel; // Level 1 bitince çıkan (Next butonlu)
    public GameObject gameFinishedPanel;  // YENİ: Level 2 bitince çıkan (Main Menu butonlu)

    [Header("Ayarlar")]
    public string nextLevelName; // Inspector'dan Level 1 için "Level2" yazacağız

    void Start()
    {
        // Başlarken tüm panelleri kapatıyoruz
        if (pausePanel != null) pausePanel.SetActive(false);
        if (levelCompletePanel != null) levelCompletePanel.SetActive(false);
        if (gameFinishedPanel != null) gameFinishedPanel.SetActive(false);
    }

    public void PauseButton()
    {
        if (pausePanel != null) pausePanel.SetActive(true);
        if (GameManager.Instance != null) GameManager.Instance.PauseGame(true);
    }

    public void ResumeButton()
    {
        if (pausePanel != null) pausePanel.SetActive(false);
        if (GameManager.Instance != null) GameManager.Instance.PauseGame(false);
    }

    public void MainMenuButton() // Hem Pause menüsündeki hem de Final Panelindeki buton buna bağlanacak
    {
        // GameManager varsa onu kullan, yoksa direkt sahne yükle (Garanti olsun)
        if (GameManager.Instance != null)
            GameManager.Instance.LoadLevel("GameStart");
        else
            SceneManager.LoadScene("GameStart"); // Senin ana menü sahnenin adı
    }

    public void NextLevelButton() // Level 1 sonundaki "Sonraki" butonu buna bağlanacak
    {
        if (GameManager.Instance != null)
            GameManager.Instance.LoadLevel(nextLevelName);
        else
            SceneManager.LoadScene(nextLevelName);
    }

    public void ToggleAudio()
    {
        if (GameManager.Instance != null) GameManager.Instance.ToggleAudio();
    }

    // Level 1 bitişi için (Eskisi gibi kalsın)
    public void ShowLevelComplete()
    {
        if (levelCompletePanel != null) levelCompletePanel.SetActive(true);
        if (GameManager.Instance != null) GameManager.Instance.PauseGame(true);
    }

    // YENİ: Level 2 bitişi için (Final Paneli)
    public void ShowGameFinished()
    {
        if (gameFinishedPanel != null) gameFinishedPanel.SetActive(true);
        if (GameManager.Instance != null) GameManager.Instance.PauseGame(true);
    }
}