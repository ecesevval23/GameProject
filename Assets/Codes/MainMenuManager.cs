using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject mainPanel;
    public GameObject mainMenuPanel;

    [Header("Level Butonları")]
    public Button level2Button;

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("LevelReached", 1);

        if (level2Button != null)
        {
            if (unlockedLevel < 2)
                level2Button.interactable = false; // Kilitli
            else
                level2Button.interactable = true;  // Açık
        }
    }
    public void OpenLevelSelect()
    {
        mainPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void BackToMain()
    {
        mainMenuPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Oyundan Çıkıldı!");
    }
}