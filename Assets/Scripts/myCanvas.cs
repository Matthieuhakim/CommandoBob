using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myCanvas : MonoBehaviour {

    public GameObject gameOverPrefab;
    public GameObject pausedPrefab;
    private bool didDisplayGameOverScreen;
    private bool didDisplayPausedScreen;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ComandoController.didCollide && !didDisplayGameOverScreen)
        {
            DisplayGameOverScreen();
            didDisplayGameOverScreen = true;
        }

        if(ComandoController.isPaused && !didDisplayPausedScreen){
            DisplayPausedScreen();
            didDisplayPausedScreen = true;
        }else if(!ComandoController.isPaused && didDisplayPausedScreen){
            DestroyPausedScreen();
            didDisplayPausedScreen = false;
        }
    }

    private void DisplayGameOverScreen()
    {
        if (gameOverPrefab != null)
        {
            Instantiate(gameOverPrefab, this.transform);
        }
    }


    private void DisplayPausedScreen()
    {
        if (pausedPrefab != null)
        {
            Instantiate(pausedPrefab, this.transform);
        }
    }

    private void DestroyPausedScreen(){
        Destroy(GameObject.Find("PausedScreen(Clone)"));
    }
}
