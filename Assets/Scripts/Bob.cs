
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bob : MonoBehaviour
{
    private GameObject selectedBobSkin;
    private SpriteRenderer spriteRenderer;
    SkinManager instance;

    private GameObject triangle;
    public GameObject triangleSprite;

    private GameObject square;
    public GameObject squareSprite;

    bool stop = true;

    // Use this for initialization
    void Start()
    {
        instance = GameObject.Find("SkinManager").GetComponent<SkinManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectedBobSkin = instance.selectedBobSkinBox;
        var selectedImage = selectedBobSkin.transform.Find("BobSkinImage").GetComponent<Image>();


        if(selectedBobSkin.name == "SkinBox (11)"){
            spriteRenderer.sprite = selectedImage.sprite;
            spriteRenderer.color = selectedImage.color;

            float myScale = 0.13f;
            this.transform.localScale = new Vector3(myScale, myScale, myScale);
            var myCollider = GetComponent<CircleCollider2D>();
            myCollider.radius = 3.3f;

        }else if (selectedBobSkin.name == "SkinBox (12)"){
            spriteRenderer.sprite = selectedImage.sprite;
            spriteRenderer.color = selectedImage.color;

            float myScale = 0.22f;
            this.transform.localScale = new Vector3(myScale, myScale, myScale);
            var myCollider = GetComponent<CircleCollider2D>();
            myCollider.radius = 2.3f;
        }
        else if (selectedBobSkin.name == "SkinBox (16)")
        {
            spriteRenderer.sprite = selectedImage.sprite;
            spriteRenderer.color = selectedImage.color;

            float myScale = 0.27f;
            this.transform.localScale = new Vector3(myScale, myScale, myScale);
            var myCollider = GetComponent<CircleCollider2D>();
            myCollider.radius = 1.65f;
        }
        else if (selectedBobSkin.name == "SkinBox (17)")
        {
            spriteRenderer.sprite = selectedImage.sprite;
            spriteRenderer.color = selectedImage.color;

            float myScale = 0.04f;
            this.transform.localScale = new Vector3(myScale, myScale, myScale);
            var myCollider = GetComponent<CircleCollider2D>();
            myCollider.radius = 10.32497f;
            myCollider.offset = new Vector2(-0.0850141f, -1.434407f); 
        }
        else if (selectedBobSkin.name == "SkinBox (18)")
        {
            spriteRenderer.sprite = selectedImage.sprite;
            spriteRenderer.color = selectedImage.color;

            float myScale = 0.18f;
            this.transform.localScale = new Vector3(myScale, myScale, myScale);
            var myCollider = GetComponent<CircleCollider2D>();
            myCollider.radius = 2.4f;
        }
        else if (selectedBobSkin.name == "SkinBox (19)")
        {
            if (this.gameObject.name == "Bob1")
            {
                spriteRenderer.sprite = selectedImage.sprite;
                spriteRenderer.color = selectedImage.color;
                float myScale = 0.108f;
                this.transform.localScale = new Vector3(myScale, myScale, myScale);
                var myCollider = GetComponent<CircleCollider2D>();
                myCollider.radius = 4.2f;
                myCollider.offset = new Vector2(0f, 0.5f);
            }
            else if (this.gameObject.name == "Bob2")
            {
                var secondImage = selectedBobSkin.transform.Find("BobSkinImage (1)").GetComponent<Image>();
                spriteRenderer.sprite = secondImage.sprite;
                spriteRenderer.color = secondImage.color;

                float myScale = 0.18f;
                this.transform.localScale = new Vector3(myScale, myScale, myScale);
                var myCollider = GetComponent<CircleCollider2D>();
                myCollider.radius = 2.4f;
            }

        }
        else
        {
            spriteRenderer.color = selectedImage.color;
            triangle = Instantiate(triangleSprite, transform.position, Quaternion.identity);
            triangle.transform.parent = gameObject.transform;
            triangle.SetActive(false);

            square = Instantiate(squareSprite, transform.position, Quaternion.identity);
            square.transform.parent = gameObject.transform;
            square.SetActive(false);
        
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (ComandoController.score == 10)
        {
            triangle.SetActive(true);

        }
        if (ComandoController.score == 30)
        {
            triangle.SetActive(false);
            square.SetActive(true);
        }
       if(ComandoController.score == 50 && stop)
        {
            StartCoroutine(ChangeShape());
            stop = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ComandoController.didCollide = true;
        GameManager.instance.numberOfDeath += 1;
        SaveDeath(GameManager.instance.numberOfDeath);
        
        
    }

    private void SaveDeath(int death)
    {
        PlayerPrefs.SetInt("Deaths", death);
        PlayerPrefs.Save();
        GameManager.instance.numberOfDeath = death;
    }

    private IEnumerator ChangeShape()
    {
        for (int i = 0; i >= 0 ; i++)
        {
            yield return new WaitForSeconds(.2f); 
            square.SetActive(true);
            triangle.SetActive(false);
            yield return new WaitForSeconds(.2f);
            square.SetActive(false);
            triangle.SetActive(true);
        }
    }

}
