using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public bool canDrop;
	public int maxBallCount;
	public GameObject BallList;
	public GameObject ball;

	private Rigidbody body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y>0.1) {
			transform.position = new Vector3(transform.position.x,0.1f,transform.position.z);
		}

		if (canDrop && Input.GetKeyDown("space") && GameObject.Find("BallList").transform.childCount<maxBallCount) {
			DropBall();
		}
	}

	private void FixedUpdate() {
		float moveH = Input.GetAxis("Horizontal");
		float moveV = Input.GetAxis("Vertical");

		
		Vector3 movement = new Vector3(speed *moveH,-Mathf.Abs(body.velocity.y), speed *moveV);
		if (Mathf.Abs(moveH)>0 || Mathf.Abs(moveV)>0) {
			if (Mathf.Abs(moveH)>Mathf.Abs(moveV)) {
				if (moveH>0) {
					transform.rotation = Quaternion.Euler(0, 90, 0);
				
				}
				else {
					transform.rotation = Quaternion.Euler(0,270,0);
				}
			}
			else {
				if (moveV > 0) {
					transform.rotation = Quaternion.Euler(0,0,0);
				}
				else {
					transform.rotation = Quaternion.Euler(0,180,0);
				}
			}
		}
		
		//body.AddForce(movement * speed * Time.deltaTime);
		body.velocity =  movement;
		//transform.localEulerAngles = new Vector3(transform.localRotation.x,0,transform.localRotation.z);
	}

	private void DropBall() {
		if (ball) {
			var tmp = Instantiate(ball, repairPosition(transform.position+new Vector3(10,0,10)),ball.transform.rotation);
			tmp.transform.parent = BallList.transform;
			Destroy(tmp,5);
		}
	}

	private Vector3 repairPosition(Vector3 pos) {
		float p_x, p_z;
		p_x = pos.x;
		p_z = pos.z;
		int pi_x = (Convert.ToInt32(p_x) / 20) * 20;
		int pi_z = (Convert.ToInt32(p_z) / 20) * 20;
		return new Vector3(pi_x,pos.y,pi_z);
	}


}
