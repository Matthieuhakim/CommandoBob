using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour {

    private Button playButton;

    // Use this for initialization
    void Start()
    {
        playButton = GetComponent<Button>();
        playButton.onClick.AddListener(DoIt);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void DoIt()
    {
        SceneManager.LoadScene("MenuScene");
        ComandoController.score = 0;
        ComandoController.didCollide = false;
        ComandoController.isPaused = false;
    }


}
