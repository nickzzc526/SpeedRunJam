using UnityEngine;
using System.Collections;

public class Star1 : MonoBehaviour {
	
	Transform myStar2;
	public float Speed = 1f;
	public float risingSpeed = 1f;
	
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
	if(Mathf.Abs(this.transform.position.x - myStar2.position.x)<3f){
			transform.position += new Vector3(0,0,risingSpeed);
		}
	}
}
