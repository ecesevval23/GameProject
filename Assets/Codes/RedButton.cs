using UnityEngine;
using UnityEngine.SceneManagement;

public class RedButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameFinished");
        }
    }
}
