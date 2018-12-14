using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour {

	//public GameObject Explosion;

	public Vector3 pos;
	private float unitLength = 20;
	
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnDestroy() {
		//var tmp = Instantiate(Explosion, pos, transform.rotation);
		var center = pos + new Vector3(0,10,0);
		RaycastHit hit;
		if (Physics.Raycast(origin:center,direction:Vector3.left,hitInfo:out hit,maxDistance:unitLength)) {
			var tmpObj = hit.collider.gameObject;
			Debug.Log("左方"+tmpObj.name);
			Destroy(gameObject);
			if (tmpObj.CompareTag("breakable")) {
				Destroy(tmpObj);
			}
			
		}
		if (Physics.Raycast(origin:center,direction:Vector3.right,hitInfo:out hit,maxDistance:unitLength)) {
			var tmpObj = hit.collider.gameObject;
			Debug.Log("右方"+tmpObj.name);
			Destroy(gameObject);
			if (tmpObj.CompareTag("breakable")) {
				Destroy(tmpObj);
			}
		}
		if (Physics.Raycast(origin:center,direction:Vector3.forward,hitInfo:out hit,maxDistance:unitLength)) {
			var tmpObj = hit.collider.gameObject;
			Debug.Log("前方"+tmpObj.name);
			Destroy(gameObject);
			if (tmpObj.CompareTag("breakable")) {
				Destroy(tmpObj);
			}
		}
		if (Physics.Raycast(origin:center,direction:Vector3.back,hitInfo:out hit,maxDistance:unitLength)) {
			var tmpObj = hit.collider.gameObject;
			Debug.Log("后方"+tmpObj.name);
			Destroy(gameObject);
			if (tmpObj.CompareTag("breakable")) {
				Destroy(tmpObj);
			}
		}
		//Destroy(tmp,2);
	}
}
