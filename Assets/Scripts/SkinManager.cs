using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{

    public static SkinManager instance;
    public GameObject selectedBobSkinBox;
    public GameObject selectedRopeSkinBox;

    public GameObject[] bobSkins;
    public GameObject[] ropeSkins;


    // Use this for initialization
    void Start()
    {

    }
    private void Awake()
    {
        SearchForSelectedBobSkin();
        SearchForSelectedRopeSkin();
    }


    // Update is called once per frame
    void Update()
    {

    }


    public void SearchForSelectedBobSkin()
    {
        foreach(var bobSkin in bobSkins){
            if(bobSkin.name == PlayerPrefs.GetString("SelectedBobSkinBox")){
                selectedBobSkinBox = bobSkin;
            }
        }


        if (selectedBobSkinBox == null){
            selectedBobSkinBox = bobSkins[0];
        }
    }
    public void SearchForSelectedRopeSkin()
    {
        foreach (var ropeSkin in ropeSkins)
        {
            if(ropeSkin.name == PlayerPrefs.GetString("SelectedRopeSkinBox")){
                selectedRopeSkinBox = ropeSkin;
            } 
        }
        if(selectedRopeSkinBox == null){
            selectedRopeSkinBox = ropeSkins[0];
        }
    }
}