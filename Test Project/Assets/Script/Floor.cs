using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class JsonItemList {
	public List<Item> Items;
	public int total;
}
[Serializable]
public class Item {
	public int id;
	public string name;
	public int relpos_x;
	public int relpos_z;
	public int angle;
}

public class Floor : MonoBehaviour {

    public GameObject cube;
	public int floorWidth= 8;
	public int floorLength = 12;
    public MeshFilter mf;
    public GameObject floor;
	public bool infiniteTime;
	public GameObject SchoolBag,Chair,Desk,LongDesk,Podium;
    public List<List<GameObject>> FloorList = new List<List<GameObject>>();
	
	public List<GameObject> ItemList = new List<GameObject>();
	public Dictionary<int,GameObject> indexDict = new Dictionary<int, GameObject>();

	public GameObject objectitemList;
	private int actionMove = 10;
	private float tile_height=2;
	private int timeInterval = 3;
	private int beginWaitTime = 7;
	private int unitLength = 20;
    private int count = -5;
    private static int delta = 5;
	private GameObject tmp;

    // Use this for initialization
    void Start () {

	    initFloors();
	    indexDict.Add(1,SchoolBag);
	    indexDict.Add(2, Chair);
	    indexDict.Add(5,Podium);
	    indexDict.Add(6,Desk);
	    loadItemsByJsonFile("Map1.json");

    }
	
	// Update is called once per frame
	void Update () {
        



		if (!infiniteTime) {
			for (int i = 0; i < floorLength; i++) {
				for (int j = 0; j < floorWidth; j++) {
					if (FloorList[i][j]!=null) {
						if (Time.timeSinceLevelLoad> beginWaitTime+i*timeInterval) {
							Vector3 obj_p = FloorList[i][j].transform.position;
							FloorList[i][j].transform.DOMove(obj_p-new Vector3(0,60,0), Random.Range(0f, 4f));
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
			for (int j = 0; j < floorWidth; j++) {
				if (FloorList.Count >i && FloorList[i].Count>j && FloorList[i][j]!=null) {
					float f_y = FloorList[i][j].GetComponent<Rigidbody>().velocity.x;
					FloorList[i][j].GetComponent<Rigidbody>().velocity = new Vector3(0.0f,f_y,0.0f);
				}
			}
			
		}
	
	}

	private void FixedUpdate() {
		
	}

	private void initFloors() {
		for (int count = 0; count < floorLength* delta; count++) {
			if (count % delta == 0 && count < floorLength* delta )
			{
				int i = count / delta;
				List<GameObject> temlist = new List<GameObject>();
				for (int j = 0; j < floorWidth; j++) {
					var randomHeight = Random.Range(5f, 15f);
					tmp = GameObject.Instantiate(cube, 
						new Vector3(unitLength * i, -(actionMove+randomHeight), unitLength * j), 
						Quaternion.identity);
					tmp.transform.parent = floor.transform;
					tmp.transform.DOMove(new Vector3(unitLength * i, 0, unitLength * j), Random.Range(0f, 4f));
					temlist.Add(tmp);


				}
				FloorList.Add(temlist);
			}
		}
	}
	
	private void loadItemsByJsonFile(string Jsonname) {
		string jsonString = File.ReadAllText(Application.dataPath+ @"/Maps/" + Jsonname);
		JsonItemList itemList = JsonUtility.FromJson<JsonItemList>(jsonString);
		
		Debug.Log(itemList.total);
		foreach (var item in itemList.Items) {
			var rangeHeight = Random.Range(20f, 40f);
			var tmp = Instantiate(indexDict[item.id],
				new Vector3(item.relpos_x * unitLength, tile_height+actionMove*4+rangeHeight, item.relpos_z * unitLength),
				Quaternion.Euler(0, item.angle, 0));
			
			tmp.transform.parent = objectitemList.transform;
			tmp.transform.DOMove(new Vector3(item.relpos_x * unitLength, tile_height,
				item.relpos_z * unitLength), Random.Range(0f, 4f));
		}
	}
	private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("物体接触了");
    }
}
