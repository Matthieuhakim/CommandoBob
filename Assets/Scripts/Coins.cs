using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

    private Text text;
    GameManager instance;

    // Use this for initialization
    void Start()
    {
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
        text = GetComponent<Text>();

        var savedCoins = PlayerPrefs.GetInt("Coins");
        text.text = "Coins: " + savedCoins.ToString();
        instance.coins = savedCoins;

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Coins: " + instance.coins;
    }
}
