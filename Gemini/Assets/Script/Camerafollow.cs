using UnityEngine;
using System.Collections;

public class Camerafollow : MonoBehaviour {
	
	
	Transform myStar1;
	// Use this for initialization
	void Start () {
	myStar1 = GameObject.FindGameObjectWithTag("Star1").transform;
	}
	
	// Update is called once per frame
	void Update () {
	this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,myStar1.position.z);
	}
}
