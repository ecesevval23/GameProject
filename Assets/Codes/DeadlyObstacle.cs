using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadlyObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("YANDIN! Sahne Yenileniyor ve Puan Sıfırlanıyor...");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.RestartGame();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}