using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private bool didAddScore = false;
    private GameObject bob1;
    private GameObject bob2;

	// Use this for initialization
	void Start () {
        bob1 = GameObject.Find("Bob1");
        bob2 = GameObject.Find("Bob2");
	}
	
	// Update is called once per frame
	void Update () {
        AddScoreIfNeeded();
	}

    void AddScoreIfNeeded(){
        if (transform.position.x <= bob1.transform.position.x && transform.position.x <= bob2.transform.position.x && !didAddScore)
        {
            ComandoController.score += 1;
            didAddScore = true;
            GameManager.instance.coins += 2;

            if(ComandoController.score < GameManager.instance.highScore){
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.pointScored);
            }else if(ComandoController.score >= GameManager.instance.highScore){
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.highScoreIncrease);
                GameManager.instance.coins += 3;
            }
            SaveCoins(GameManager.instance.coins);
        }
    }
    private void SaveCoins(int coins)
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
        GameManager.instance.coins = coins;
    }
}
