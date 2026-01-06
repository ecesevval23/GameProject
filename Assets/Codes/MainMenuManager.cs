using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Senin Panellerin")]
    public GameObject mainPanel;      // Hiyerarşindeki "Main" objesi
    public GameObject mainMenuPanel;  // Hiyerarşindeki "MainMenu" objesi

    [Header("Level Butonları")]
    public Button level2Button;       // MainMenu içindeki "Level2" butonu

    void Start()
    {
        // Oyun açıldığında hafızaya bak, Level 2'yi aç/kapat
        int unlockedLevel = PlayerPrefs.GetInt("LevelReached", 1);

        if (level2Button != null) // Hata vermesin diye kontrol ediyoruz
        {
            if (unlockedLevel < 2)
                level2Button.interactable = false; // Kilitli
            else
                level2Button.interactable = true;  // Açık
        }
    }

    // "Start" Butonuna Bağlanacak (Main'i kapat, MainMenu'yu aç)
    public void OpenLevelSelect()
    {
        mainPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // "Back" Butonuna Bağlanacak (MainMenu'yu kapat, Main'i aç)
    public void BackToMain()
    {
        mainMenuPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    // "Level 1" Butonuna
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1"); // Senin sahne adın neyse onu yaz (SampleScene olabilir)
    }

    // "Level 2" Butonuna
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    // "Quit" Butonuna
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Oyundan Çıkıldı!");
    }
}