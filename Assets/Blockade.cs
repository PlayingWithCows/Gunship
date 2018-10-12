using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockade : MonoBehaviour {

    private Player player;
	// Update is called once per frame
	void Update () {
        InvokeRepeating("CheckChildren", 1, 1);
	}

    void CheckChildren()
    {
        if (transform.childCount == 0)
        {
            if(player != null)
            {
                player.Accelerate();
            }
            Destroy(gameObject,1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.attachedRigidbody.transform.GetComponent<Player>() != null)
        {
            player = other.attachedRigidbody.transform.GetComponent<Player>();
            player.Decelerate();
            
        }
    }
}
