using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShading : MonoBehaviour {

    private bool weDidIt;

    private bool weDidDarkenForPaused;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ComandoController.didCollide && !weDidIt)
        {
            var spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1, 1, 1, 0.7f);
            weDidIt = true;
        }
        if (ComandoController.isPaused && !weDidDarkenForPaused)
        {
            var spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1, 1, 1, 0.7f);
            weDidDarkenForPaused = true;
        }
        else if (!ComandoController.isPaused && weDidDarkenForPaused)
        {
            var spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1, 1, 1, 1);
            weDidDarkenForPaused = false;
        }
    }
}
