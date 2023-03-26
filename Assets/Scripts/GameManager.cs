using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour {


    public static GameManager instance;
    public int highScore;
    public int coins;
    public int numberOfDeath;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }


    public void RestartLevel(float delay)
    {
        SceneManager.LoadScene("MainScene");
        ComandoController.score = 0;
        ComandoController.didCollide = false;
        ComandoController.isPaused = false;
    }

   
}
