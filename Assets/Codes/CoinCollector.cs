using UnityEngine;
using TMPro;
public class CoinCollector : MonoBehaviour
{
    public static int coinValue = 0;
    private bool isCollected = false;
    [SerializeField] private TMP_Text coinText;
    void Update()
    {
        transform.Rotate(0, 90f * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
         if (!isCollected && other.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    public void CollectCoin()
    {
        isCollected = true;
        coinValue++;
        Debug.Log("Coin collected! Value: " + coinValue);
        if (coinText != null)
        {
            coinText.text = "X " + coinValue;
        }

        Destroy(gameObject);
    }
}