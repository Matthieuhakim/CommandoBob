using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinBox : MonoBehaviour {

    public Button ownedButton;
    public Button selectedButton;
    public Button priceButton;
    SkinManager instance;

	// Use this for initialization
	void Start () {
        priceButton.gameObject.SetActive(true);
        ownedButton.gameObject.SetActive(false);
        selectedButton.gameObject.SetActive(false);

        instance = GameObject.Find("SkinManager").GetComponent<SkinManager>();

        ownedButton.onClick.AddListener(DoIt);
        priceButton.onClick.AddListener(DoItAgain);

        var savedSkinName = PlayerPrefs.GetString("SelectedBobSkinBox");
        var isOwnedSkin = PlayerPrefs.GetString(gameObject.name);

        if(isOwnedSkin == "true" || gameObject.name == "SkinBox"){
            priceButton.gameObject.SetActive(false);
            ownedButton.gameObject.SetActive(true);
        }


        if (!string.IsNullOrEmpty(savedSkinName) && savedSkinName == gameObject.name)
        {
            ExchangeSelectedButton();

        }
        if (!string.IsNullOrEmpty(savedSkinName))
        {
            instance.selectedBobSkinBox = GameObject.Find(savedSkinName);
        }
        


    }
	
	// Update is called once per frame
	void Update () {
        if(gameObject == instance.selectedBobSkinBox){
            ExchangeSelectedButton();
        }
	}
    void DoIt(){
        ExchangeSelectedButton();
        SaveBobSkinName(this.gameObject.name);


    }

    private void SaveBobSkinName(string bobSkinName)
    {
        PlayerPrefs.SetString("SelectedBobSkinBox", bobSkinName);
        PlayerPrefs.Save();
        instance.selectedBobSkinBox = this.gameObject;
    }

    private void ExchangeSelectedButton(){
        instance.selectedBobSkinBox.GetComponent<SkinBox>().selectedButton.gameObject.SetActive(false);
        ownedButton.gameObject.SetActive(false);
        selectedButton.gameObject.SetActive(true);
        instance.selectedBobSkinBox.GetComponent<SkinBox>().ownedButton.gameObject.SetActive(true);
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
