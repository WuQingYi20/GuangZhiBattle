using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour {

	public GameObject Explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnDestroy() {
		var tmp = Instantiate(Explosion, transform.position, transform.rotation);
		Destroy(tmp,3);
	}
}
