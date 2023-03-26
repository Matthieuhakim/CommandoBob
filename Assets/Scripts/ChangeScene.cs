using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    private Button playButton;

	// Use this for initialization
	void Start () {
        playButton = GetComponent<Button>();
        playButton.onClick.AddListener(DoIt);
	}
	
	// Update is called once per frame
	void Update () {
	}
 
    void DoIt(){
        GoToMainScene(0f);
    }

    public void GoToMainScene(float delay){
        StartCoroutine(GoToMainSceneDelay(delay));
    }

    private IEnumerator GoToMainSceneDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainScene");
        ComandoController.score = 0;
        ComandoController.didCollide = false;
    }
}
