using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public GameObject cube;
    public MeshFilter mf;
    public List<GameObject> FloorList = new List<GameObject>();
    private int count = -5;
    private bool finishflag = false;
    private static int delta = 5;

    // Use this for initialization
    void Start () {
        /*
        for(int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                FloorList.Add(GameObject.Instantiate(cube, new Vector3(20 * i, -20, 20 * j), Quaternion.identity));
                
                if (i == 15 || j == 15 || j == 0 || i == 0||(j+i)==14)
                {
                    FloorList.Add(GameObject.Instantiate(cube, new Vector3(20 * i, 0, 20 * j), Quaternion.identity));

                }
            }
                
        }*/
            

    }
	
	// Update is called once per frame
	void Update () {
        count++;
        if (count % delta == 0 && count < 16* delta)
        {
            int i = count / delta;
            for (int j = 0; j < 16; j++)
            {
                FloorList.Add(GameObject.Instantiate(cube, new Vector3(20 * i, -20, 20 * j), Quaternion.identity));

                if (i == 15 || j == 15 || j == 0 || i == 0 || (j + i) == 14)
                {
                    FloorList.Add(GameObject.Instantiate(cube, new Vector3(20 * i, 0, 20 * j), Quaternion.identity));

                }
            }
        }
        if (!finishflag)
        {
            foreach (var obj in FloorList)
            {
                obj.gameObject.AddComponent<BoxCollider>();
            }
            finishflag = true;
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("物体接触了");
    }
}
