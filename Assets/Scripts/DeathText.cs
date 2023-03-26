using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathText : MonoBehaviour
{
    private Text text;
    GameManager instance;

    // Use this for initialization
    void Start()
    {
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
        text = GetComponent<Text>();

        var savedDeath = PlayerPrefs.GetInt("Deaths");
        text.text = "Death: " + savedDeath.ToString();
        instance.numberOfDeath = savedDeath;

    }

    // Update is called once per frame
    void Update()
    {
    }
}
