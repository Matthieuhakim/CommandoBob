using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPromoCode : MonoBehaviour
{
    public string promoText;



    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.EndEditEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

    }

    private void SubmitName(string arg0)
    {
        if(arg0 == promoText && PlayerPrefs.GetString("DidEnterPromoCode") != "true")
        {
            StartCoroutine("PlaySound");


            PlayerPrefs.SetString("DidEnterPromoCode", "true");
            PlayerPrefs.Save();


        }
    }


    private IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(0.1f);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.pointScored);
        GameManager.instance.coins += 10;
        PlayerPrefs.SetInt("Coins", GameManager.instance.coins);

        yield return new WaitForSeconds(0.1f);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.pointScored);
        GameManager.instance.coins += 10;
        PlayerPrefs.SetInt("Coins", GameManager.instance.coins);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(0.1f);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.pointScored);
        GameManager.instance.coins += 10;
        PlayerPrefs.SetInt("Coins", GameManager.instance.coins);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(0.1f);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.pointScored);
        GameManager.instance.coins += 10;
        PlayerPrefs.SetInt("Coins", GameManager.instance.coins);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(0.1f);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.pointScored);
        GameManager.instance.coins += 10;
        PlayerPrefs.SetInt("Coins", GameManager.instance.coins);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(0.1f);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.pointScored);
        GameManager.instance.coins += 10;
        PlayerPrefs.SetInt("Coins", GameManager.instance.coins);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(0.02f);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.highScoreIncrease);
        GameManager.instance.coins += 40;
        PlayerPrefs.SetInt("Coins", GameManager.instance.coins);
        PlayerPrefs.Save();
    }
}