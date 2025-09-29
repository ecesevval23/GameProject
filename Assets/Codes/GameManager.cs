using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public PlayerController player;
    void Start()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        playButton.SetActive(true);
    }
    
    public void StartGame()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        playButton.SetActive (false);
    }

}
