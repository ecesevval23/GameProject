using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject pausePanel;
    public GameObject levelCompletePanel; // Level 1 bitince
    public GameObject gameFinishedPanel;  // Level 2 bitince

    [Header("Ayarlar")]
    public string nextLevelName;

    void Start()
    {
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
    public void MainMenuButton()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.LoadLevel("GameStart");
        else
            SceneManager.LoadScene("GameStart");
    }

    public void NextLevelButton()
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

    // Level 1 bitişi için
    public void ShowLevelComplete()
    {
        if (levelCompletePanel != null) levelCompletePanel.SetActive(true);
        if (GameManager.Instance != null) GameManager.Instance.PauseGame(true);
    }

    //Level 2 bitişi için
    public void ShowGameFinished()
    {
        if (gameFinishedPanel != null) gameFinishedPanel.SetActive(true);
        if (GameManager.Instance != null) GameManager.Instance.PauseGame(true);
    }
}