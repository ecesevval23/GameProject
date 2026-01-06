using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 90f * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(1);

            Destroy(gameObject);
        }
    }
}