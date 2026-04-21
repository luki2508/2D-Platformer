using System;
using TMPro;
using UnityEngine;

public class UICoinDisplay : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public PlayerCoins PlayerCoins;


    void Awake()
    {
        PlayerCoins.OncoinChanged += OnCoinChanged;
        PlayerCoins.OncoinInitialised += OnCoinInit;

    }

  

    private void OnCoinInit(float newCoin)
    {
        CoinText.text = newCoin.ToString();
    }

    public void OnCoinChanged(float newCoin, float ammountChanged)
    {
        // Debug.Log("On Health Changed Event");
        CoinText.text = newCoin.ToString();
    }








}
