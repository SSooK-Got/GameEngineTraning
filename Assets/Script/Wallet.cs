using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    private Text coinText;
    private int currentCoin;

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentCoin = player.wallet;
        coinText.text = "Coin :" + currentCoin;
    }
}
