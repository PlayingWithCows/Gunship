using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockade : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        InvokeRepeating("CheckChildren", 1, 1);
	}

    void CheckChildren()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject,1f);
        }
    }
}
