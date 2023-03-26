using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectiveText : MonoBehaviour
{

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        var savedHighScore = PlayerPrefs.GetInt("HighScore");
        if(savedHighScore < 10)
        {
            text.text += " 10";
        }
        else if(savedHighScore < 30)
        {
            text.text += " 30";
        }
        else if (savedHighScore < 50)
        {
            text.text += " 50";
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
