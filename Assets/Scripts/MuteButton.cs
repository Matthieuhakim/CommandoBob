using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

    private Button muteButton;
    public Text muteStatusText;
    SoundManager instance;


    // Use this for initialization
    void Start()
    {
        instance = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        muteButton = GetComponent<Button>();
        muteButton.onClick.AddListener(DoIt);


        var isMutedString = PlayerPrefs.GetString("isMuted");
        if(isMutedString == "true"){
            muteStatusText.text = ": OFF";
        }else if (isMutedString == "false"){
            muteStatusText.text = ": ON";
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

    void DoIt()
    {
        if(muteStatusText.text == ": ON")
        {

            muteStatusText.text = ": OFF";
            instance.backgrounAudioSource.volume = 0f;
            PlayerPrefs.SetString("isMuted", "true");
            PlayerPrefs.Save();
        }
        else if (muteStatusText.text == ": OFF")
        {
            muteStatusText.text = ": ON";
            instance.backgrounAudioSource.volume = 1f;
            PlayerPrefs.SetString("isMuted", "false");
            PlayerPrefs.Save();
        }
    }
}
