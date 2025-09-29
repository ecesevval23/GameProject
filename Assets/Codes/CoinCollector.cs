using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int coinValue = 10;
    void Update()
    {
        transform.Rotate(0, 90f * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    public void CollectCoin()
    {
        Debug.Log("Coin collected! Value: " + coinValue);

        Destroy(gameObject);
    }
}