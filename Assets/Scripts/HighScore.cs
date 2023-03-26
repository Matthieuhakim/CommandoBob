using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    private Text text;
    int score = 1;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();

        var savedHighScore = PlayerPrefs.GetInt("HighScore");
        text.text = "High Score: " + savedHighScore.ToString();
        GameManager.instance.highScore = savedHighScore;
    }

    // Update is called once per frame
    void Update () {
        text.text = "High Score: " + GameManager.instance.highScore.ToString();

    }

}
