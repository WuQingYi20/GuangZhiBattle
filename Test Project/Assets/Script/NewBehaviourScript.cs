using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public int MoveSpeed = 1000;
    private Rigidbody rbody;
    private Transform tform;
	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
        tform = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update() {
        UpdateMove();
        if (Input.anyKeyDown)
        {
            foreach(KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    
                }
            }
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Debug.LogError("Current Key is : ");
            rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, MoveSpeed);
            tform.rotation = Quaternion.Euler(tform.rotation.x, 0, tform.rotation.z);
        
        }
            

    }

    void UpdateMove()
    {
        if (Input.GetKey(KeyCode.W))
        { //Up movement
            rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, MoveSpeed);
            tform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        { //Left movement
            rbody.velocity = new Vector3(-MoveSpeed, rbody.velocity.y, rbody.velocity.z);
            tform.rotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetKey(KeyCode.S))
        { //Down movement
            rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, -MoveSpeed);
            tform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.D))
        { //Right movement
            rbody.velocity = new Vector3(MoveSpeed, rbody.velocity.y, rbody.velocity.z);
            tform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy(this.gameObject);
    }
}
