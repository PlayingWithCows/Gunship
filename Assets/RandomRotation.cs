using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

    Vector3 rotation;
    private void Start()
    {
        rotation = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
    private void Update()
    {
        transform.Rotate(rotation.x, rotation.y, rotation.z);
    }

}
