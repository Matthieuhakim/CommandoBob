using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    public static SoundManager Instance = null;
    public AudioSource soundEffectAudio;
    public static SoundManager instance;
    public AudioSource backgrounAudioSource;
    public AudioClip changingCenter;
    public AudioClip higherSpeed;
    public AudioClip highScoreIncrease;
    public AudioClip pointScored;
    public AudioClip objctHit;
    

    public GameObject selectedBgMusicBox;
    public GameObject[] bgMusics;

    private bool itHappened = false;
    private bool itHappenedTwice = false;
    private void Awake()
    {
        SearchForSelectedBgMusic();
    }
    // Use this for initialization
    void Start()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }



        if (PlayerPrefs.GetString("isMuted") == "true")
        {
            backgrounAudioSource.volume = 0;
        }
        else if (PlayerPrefs.GetString("isMuted") == "false")
        {
            backgrounAudioSource.volume = 1;
        }

        SearchForSelectedBgMusic();

        backgrounAudioSource.PlayOneShot(selectedBgMusicBox.GetComponent<BgMusicBox>().bgClip, 0.6f);
    }
    

    // Update is called once per frame
    void Update () {
        var oldSong = selectedBgMusicBox;
        SearchForSelectedBgMusic();

        if(ComandoController.didCollide && !itHappened){
            soundEffectAudio.PlayOneShot(objctHit);
            Destroy(backgrounAudioSource);
            itHappened = true;
        }
        if (!itHappened)
        {
            if (!backgrounAudioSource.isPlaying)
            {
                backgrounAudioSource.PlayOneShot(selectedBgMusicBox.GetComponent<BgMusicBox>().bgClip, 0.6f);
            }
            if (oldSong != selectedBgMusicBox)
            {
                if (itHappenedTwice)
                {
                    backgrounAudioSource.Stop();
                    backgrounAudioSource.PlayOneShot(selectedBgMusicBox.GetComponent<BgMusicBox>().bgClip, 0.6f);
                }
                itHappenedTwice = true;
            }
        }
    }

    public void PlayOneShot(AudioClip clip)
    {
        if (clip == highScoreIncrease)
        {
            soundEffectAudio.PlayOneShot(clip, 0.05f);
        }else{
            soundEffectAudio.PlayOneShot(clip);
        }
    }

    private void SearchForSelectedBgMusic()
    {
        foreach (var bgMusic in bgMusics)
        {
            if (bgMusic.name == PlayerPrefs.GetString("SelectedBgMusicBox"))
            {
                selectedBgMusicBox = bgMusic;
            }
        }if (selectedBgMusicBox == null){
            selectedBgMusicBox = bgMusics[0];
        }
    }

}
