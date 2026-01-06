using UnityEngine;
using TMPro; // TextMeshPro kütüphanesi (ŞART!)

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Update()
    {
        // GameManager ve CoinText hazırsa yazıyı güncelle
        if (GameManager.Instance != null && coinText != null)
        {
            coinText.text = GameManager.Instance.totalScore.ToString();
        }
    }
}