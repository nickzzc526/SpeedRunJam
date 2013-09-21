﻿using UnityEngine;
using System.Collections;

public class CharMove1 : MonoBehaviour {
	
	public float speed = 0;
	float a = 10;
	float de = 30f;
	float speedMax = 30f;
	Transform myTr;
	float speedMin = 0f;
	bool goLeft = true;
	
	float g =10f;
	float maxG = 10f;
	
	
	public Transform otherTr;
	CharMove1 otherScrpit;
	
	public KeyCode keyLeft = KeyCode.LeftArrow;
	public KeyCode keyRight = KeyCode.RightArrow;
	
	float phi;
	float A = 0.02f, w = 1f;
	
	float actualSpeed;
	
	float upSpeed = 0;
	float upAc = 15f;
	
	float upSpeedMax = 10f;
	float upDist = 5f;
	float distMax = 30f;
	
	// Use this for initialization
	void Start () {
		myTr = transform;
		phi = Random.Range(0,Mathf.PI);
		w *= Random.Range(1,1.3f);
		speedMax *= Random.Range(1,1.3f);
		
		a *= Random.Range(1,1.3f);
		de *= Random.Range(1,1.3f);
		otherScrpit = otherTr.GetComponent<CharMove1>();
	}
	
	// Update is called once per frame
	void Update () {
		// Move Left & Right
		float aveSpeed = 0;// (otherScrpit.speed + speed)/2;
		
		if(Input.GetKey(keyLeft)){
			if(speed > speedMin + aveSpeed){
				goLeft = true;
			}
			if(speed > 0 + aveSpeed){
				speed -= de * Time.deltaTime;
			}
			else{
				speed -= a * Time.deltaTime;
			}
		}
		else if(Input.GetKey(keyRight)){
			if(speed < - speedMin + aveSpeed){
				goLeft = false;
			}
			if(speed < 0 + aveSpeed){
				speed += de * Time.deltaTime;
			}else{
				speed += a * Time.deltaTime;
			}
		}
		
		float gravity = -g/(otherTr.position.x - myTr.position.x);
		
		if(gravity > maxG){
			gravity = maxG;
		}
		else if(gravity < -maxG){
			gravity = - maxG;
		}
		
		
		speed += Time.deltaTime * gravity;
		
		if(speed > speedMax + aveSpeed){
				speed = speedMax + aveSpeed;
		}
		else if(speed < - speedMax + aveSpeed){
			speed = -speedMax + aveSpeed;
		}
		
		if(speed < speedMin + aveSpeed && speed > - speedMin + aveSpeed){
			if(goLeft){
				actualSpeed = - speedMin + aveSpeed;
			}
			else{
				actualSpeed = speedMin + aveSpeed;
			}
		}
		else{
			actualSpeed = speed + aveSpeed;
		}
		
		myTr.Translate(Vector3.right * actualSpeed * Time.deltaTime);
		//myTr.Translate(Vector3.forward * Mathf.Sin(w*Time.time + phi) * A);
		
		
		
		//Flying and Falling
		float dist = Mathf.Abs(myTr.position.x - otherTr.position.x);
		if(dist < upDist){
			upSpeed += upAc * Time.deltaTime;
		}
		else{
			upSpeed -= upAc * Time.deltaTime;
		}
		if(upSpeed > upSpeedMax){
			upSpeed = upSpeedMax;
		}
		else if(upSpeed < - upSpeedMax){
			upSpeed = - upSpeedMax;
		}
		
		myTr.Translate(Vector3.forward * upSpeed * Time.deltaTime);
		
		if(myTr.position.z < 0){
			myTr.position = new Vector3(myTr.position.x,myTr.position.y,0);
		}
		/*
		if(myTr.position.x - otherTr.position.x > distMax){
			myTr.position = new Vector3(otherTr.position.x + distMax,myTr.position.y,myTr.position.z);
		}
		*/
	}
}
