using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgMusicBox : MonoBehaviour {

    public Button ownedButton;
    public Button selectedButton;
    public Button priceButton;
    public AudioClip bgClip;
    SoundManager instance;

    // Use this for initialization
    void Start () {
        priceButton.gameObject.SetActive(true);
        ownedButton.gameObject.SetActive(false);
        selectedButton.gameObject.SetActive(false);

        instance = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        ownedButton.onClick.AddListener(DoIt);
        priceButton.onClick.AddListener(DoItAgain);

        var savedSkinName = PlayerPrefs.GetString("SelectedBgMusicBox");
        if(gameObject.name == "BgMusicBox"){
            PlayerPrefs.SetString("BgMusicBox", "true");
            PlayerPrefs.Save();
        }
        var isOwnedSkin = PlayerPrefs.GetString(gameObject.name);

        if (isOwnedSkin == "true")
        {
            priceButton.gameObject.SetActive(false);
            ownedButton.gameObject.SetActive(true);
        }


        if (!string.IsNullOrEmpty(savedSkinName) && savedSkinName == gameObject.name)
        {
            ExchangeSelectedButton();

        }
        if (!string.IsNullOrEmpty(savedSkinName))
        {
            instance.selectedBgMusicBox = GameObject.Find(savedSkinName);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name != instance.selectedBgMusicBox.name && PlayerPrefs.GetString(gameObject.name) == "true")
        {
            ownedButton.gameObject.SetActive(true);
            selectedButton.gameObject.SetActive(false);
        }
    }


    void DoIt()
    {

        ExchangeSelectedButton();
        SaveBgMusicName(this.gameObject.name);


    }

    private void SaveBgMusicName(string bgMusicName)
    {
        PlayerPrefs.SetString("SelectedBgMusicBox", bgMusicName);
        PlayerPrefs.Save();
        instance.selectedBgMusicBox = gameObject;
    }

    private void ExchangeSelectedButton()
    {
        instance.selectedBgMusicBox.GetComponent<BgMusicBox>().selectedButton.gameObject.SetActive(false);
        ownedButton.gameObject.SetActive(false);
        selectedButton.gameObject.SetActive(true);
        instance.selectedBgMusicBox.GetComponent<BgMusicBox>().ownedButton.gameObject.SetActive(true);
    }

    private void SaveOwnedSkin()
    {
        PlayerPrefs.SetString(gameObject.name, "true");
        PlayerPrefs.Save();
    }

    void DoItAgain()
    {
        if (GameManager.instance.coins >= int.Parse(priceButton.GetComponentInChildren<Text>().text))
        {
            priceButton.gameObject.SetActive(false);
            ownedButton.gameObject.SetActive(true);
            GameManager.instance.coins -= int.Parse(priceButton.GetComponentInChildren<Text>().text);
            SaveCoins(GameManager.instance.coins);
            SaveOwnedSkin();
        }
    }
    private void SaveCoins(int coins)
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
        GameManager.instance.coins = coins;
    }
}
