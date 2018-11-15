using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreateCube : MonoBehaviour {

    private float x, y, z;
	// Use this for initialization
	void Start () {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        ShortcutExtensions.DOMove(transform, new Vector3(x,y+20,z), Random.Range(0f,5f));
	}
}
