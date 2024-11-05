using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    private int totalCoins = 0;
    public Text coinsText;

    void Start()
    {
        coinsText = GameObject.Find("txtAmount").GetComponent<Text>();
        UpdateCoinsText();
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + totalCoins;
    }
}
