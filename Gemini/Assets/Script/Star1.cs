using UnityEngine;
using System.Collections;

public class Star1 : MonoBehaviour {
	
	Transform myStar2;
	public float Speed = 1;
	public float risingSpeed = 1;
	
	// Use this for initialization
	void Start () {
	myStar2 = GameObject.FindGameObjectWithTag("Star2").transform;
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKey("left")){
			transform.position += new Vector3(-Speed,0,0);
		}
	if(Input.GetKey("right")){
			transform.position += new Vector3(Speed,0,0);
		}
	if(Vector3.Distance(this.transform.position,myStar2.position)<10f){
			transform.position += new Vector3(0,0,risingSpeed);
		}
	}
}
