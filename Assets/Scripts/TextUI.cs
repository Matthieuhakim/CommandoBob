﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextUI : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + ComandoController.score.ToString();
	}
}
