using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	Transform myTr;
	float lerpSpeed = 15f;
	
	public Transform char1,char2;
	// Use this for initialization
	void Start () {
		myTr = transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 midPos = (char1.position + char2.position)/2;
		midPos = new Vector3(midPos.x,myTr.position.y,midPos.z);
		myTr.position = Vector3.Slerp(myTr.position,midPos,lerpSpeed * Time.deltaTime);
		
		
		Camera.main.orthographicSize = Vector3.Distance(char1.position,char2.position) + 3f;
		if(Camera.main.orthographicSize < 20f){
			Camera.main.orthographicSize = 20f;
		}
	}
}
