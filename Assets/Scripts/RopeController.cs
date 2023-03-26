using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeController : MonoBehaviour {

    private LineRenderer lineRenderer;
    public GameObject Bob1;
    public GameObject Bob2;

    private Vector3[] directions;
    private Vector3 vector1;
    private Vector3 vector2;

    SkinManager instance;
    private GameObject selectedRopeSkin;

	// Use this for initialization
	void Start () {
        instance = GameObject.Find("SkinManager").GetComponent<SkinManager>();
        lineRenderer = GetComponent<LineRenderer>();

        selectedRopeSkin = instance.selectedRopeSkinBox;
        var selectedImage = selectedRopeSkin.transform.Find("RopeSkinImage").GetComponent<Image>();
        if (selectedRopeSkin.name != "RopeSkinBox (7)")
        {
            lineRenderer.startColor = selectedImage.color;
            lineRenderer.endColor = selectedImage.color;
        }else if(selectedRopeSkin.name == "RopeSkinBox (7)"){
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.blue;

        }

    }
	
	// Update is called once per frame
	void Update () {
        FindPositions();
        lineRenderer.SetPositions(directions);
        FindPositions();
        lineRenderer.SetPositions(directions);
	}

    public void FindPositions(){
        vector1 = new Vector3(Bob1.transform.position.x, Bob1.transform.position.y, 0);
        vector2 = new Vector3(Bob2.transform.position.x, Bob2.transform.position.y, 0);
        directions = new Vector3[2];
        directions[0] = vector1;
        directions[1] = vector2;
    }
}
