using UnityEngine;
using System.Collections;

public class Star2 : MonoBehaviour {
	
	Transform myStar1;
	public float Speed = 1;
	public float risingSpeed = 1;
	
	// Use this for initialization
	void Start () {
	myStar1 = GameObject.FindGameObjectWithTag("Star1").transform;
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKey(KeyCode.A)){
			transform.position += new Vector3(-Speed,0,0);
		}
	if(Input.GetKey(KeyCode.D)){
			transform.position += new Vector3(Speed,0,0);
		}
	if(Mathf.Abs(this.transform.position.x - myStar1.position.x)<3f){
			transform.position += new Vector3(0,0,risingSpeed);
		}
	}
}
