using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Update()
    {
        if (GameManager.Instance != null && coinText != null)
        {
            coinText.text = GameManager.Instance.totalScore.ToString();
        }
    }
}