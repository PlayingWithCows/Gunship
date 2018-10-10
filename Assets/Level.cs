using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    public float mapPartHeight;
    public int mapLength;
    public List<GameObject> mapParts;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < mapLength; i++)
        {
            Vector3 pos = new Vector3(0, mapPartHeight*i, 0);
            Instantiate(mapParts[Random.Range(0, mapParts.Count)], pos, Quaternion.identity, transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
