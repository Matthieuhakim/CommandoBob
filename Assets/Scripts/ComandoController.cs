using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComandoController : MonoBehaviour
{
    public static ComandoController instance;
    public GameObject bob1;
    public GameObject bob2;
    public float radius = 3f;
    public float rotateSpeed = 2f;
    public static Transform center;
    private float timeCounter = 0f;
    private float angle;
    public static bool didCollide = false;
    public static int score;
    private int oldScore;

    public static bool isPaused = false;
    public static bool previousStateOfPausedButton = false;

    // Use this for initialization
    void Start()
    {
        center = bob1.transform;

    }

    // Update is called once per frame
    void Update()
    {
        SpinBobs();
        if(score >= GameManager.instance.highScore){
            SaveHighScore(score);

        }
        if(oldScore != score){
            IncreaseSpeedWhenNeeded();
        }
        oldScore = score;
        previousStateOfPausedButton = isPaused;
    }

    private void RevertCenterOnClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (center == bob1.transform)
            {
                center = bob2.transform;
            }
            else if (center == bob2.transform)
            {
                center = bob1.transform;
            }
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.changingCenter);
        }
    }

    private void SpinBobs()
    {
        if (!didCollide && !isPaused && !previousStateOfPausedButton)
        {

            RevertCenterOnClick();
            
            timeCounter = Time.deltaTime;

            angle += timeCounter * -rotateSpeed;


            if (center == bob1.transform)
            {
                bob2.transform.position = new Vector3(Mathf.Sin(angle + (Mathf.PI / 4)), Mathf.Cos(angle + (Mathf.PI / 4)), 0) * radius + center.position;
            }
            else if (center == bob2.transform)
            {
                bob1.transform.position = new Vector3(Mathf.Sin(Mathf.PI + angle + (Mathf.PI / 4)), Mathf.Cos(Mathf.PI + angle + (Mathf.PI / 4)), 0) * radius + center.position;
            }
            
        }
    }

    private void SaveHighScore(int highScore){
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
        GameManager.instance.highScore = highScore;
    }

    public void IncreaseSpeedWhenNeeded(){
        if(CheckIfSpeedIncreaseIsNeeded()){
            if (rotateSpeed < 3f)
            {
                rotateSpeed += 0.2f;
            }else if (rotateSpeed < 4.2f){
                rotateSpeed += 0.1f;
            }
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.higherSpeed);
        }
    }

    private bool CheckIfSpeedIncreaseIsNeeded(){
        if (score != 0)
        {
            if ((score % 5) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
