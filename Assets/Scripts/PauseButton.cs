using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {


    public Sprite[] buttonSprites;
    private Image buttonImage;


    // Use this for initialization
    void Start()
    {

        buttonImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public void DoIt()
    {
        if (!ComandoController.didCollide)
        {
            if (buttonImage.sprite == buttonSprites[0])
            {
                ComandoController.isPaused = true;
                buttonImage.sprite = buttonSprites[1];

            }
            else if (buttonImage.sprite = buttonSprites[1])
            {
                ComandoController.isPaused = false;
                buttonImage.sprite = buttonSprites[0];
            }
        }
    }

  

}
