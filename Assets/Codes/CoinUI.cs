using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public Text coinText;
    void Start()
    {
        UpdateCoinText(0);
    }
    public void UpdateCoinText(int coinValue)
    {
        coinText.text = "X " + coinValue;
    }
}
