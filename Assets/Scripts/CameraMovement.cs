using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float trackingSpeed;
    private static Transform target;
    public float offset;

	// Use this for initialization
	void Start () {
        target = ComandoController.center;
	}
	
	// Update is called once per frame
	void Update () {
        target = ComandoController.center;

        if (target != null && !ComandoController.didCollide && !ComandoController.isPaused && !ComandoController.previousStateOfPausedButton){

            var newPos = Vector2.Lerp(transform.position, target.position, trackingSpeed * Time.deltaTime);
            var v3 = new Vector3(newPos.x, 0, -10);
            var oldPosition = transform.position;
            var newPosition = new Vector3(v3.x + offset, 0, -10);
            if(oldPosition.x < newPosition.x){
                transform.position = newPosition;
            }else{
                transform.position = oldPosition;
            }

        }


        

	}
}
