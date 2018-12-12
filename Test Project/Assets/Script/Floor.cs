using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Floor : MonoBehaviour {

    public GameObject cube;
	public int floorLength = 16;
    public MeshFilter mf;
    public GameObject floor;
	public bool infiniteTime;
    public List<List<GameObject>> FloorList = new List<List<GameObject>>();
    private int count = -5;
    private bool finishflag = false;
    private static int delta = 5;
	private GameObject tmp;
    private bool initFlag = false;

    // Use this for initialization
    void Start () {

            

    }
	
	// Update is called once per frame
	void Update () {
        count++;
        if (count % delta == 0 && count < floorLength* delta && !initFlag)
        {
            int i = count / delta;
	        List<GameObject> temlist = new List<GameObject>();
            for (int j = 0; j < floorLength; j++) {
                tmp = GameObject.Instantiate(cube, new Vector3(20 * i, -10, 20 * j), Quaternion.identity);
                tmp.transform.parent = floor.transform;
	            tmp.transform.DOMove(new Vector3(20 * i, 0, 20 * j), Random.Range(0f, 2f));
                temlist.Add(tmp);


            }
	        FloorList.Add(temlist);
        }

	    if (count>floorLength*delta) {
		    initFlag = true;
	    }


		if (!infiniteTime) {
			for (int i = 0; i < floorLength; i++) {
				for (int j = 0; j < floorLength; j++) {
					if (FloorList[i][j]!=null) {
						if (Time.timeSinceLevelLoad> 5+i*2) {
							Vector3 obj_p = FloorList[i][j].transform.position;
							FloorList[i][j].transform.DOMove(obj_p-new Vector3(0,60,0), Random.Range(0f, 5f));
						}
					}
				}
			
			}
		}
	    /*if (Time.time>5) {
	        foreach (Transform child in floor.transform) {
				Vector3 obj_p = child.position;
	            child.transform.DOMove(obj_p-new Vector3(0,60,0), Random.Range(0f, 5f));

	        }
	    }*/
		for (int i = 0; i < floorLength; i++) {
			for (int j = 0; j < floorLength; j++) {
				if (FloorList[i][j]!=null) {
					float f_y = FloorList[i][j].GetComponent<Rigidbody>().velocity.x;
					FloorList[i][j].GetComponent<Rigidbody>().velocity = new Vector3(0.0f,f_y,0.0f);
				}
			}
			
		}
	
	}

	private void FixedUpdate() {
		
	}

	private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("物体接触了");
    }
}
