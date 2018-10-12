using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float boatMaxSpeed;
    public float acceleration;
    public float brakeDistance;

    public float desiredSpeed;
    public float currentSpeed;
    public Vector3 brakeSpot;
    public bool blockade = false;

	// Use this for initialization
	void Start () {
        Accelerate();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        ChangeSpeed();
        transform.Translate(0, currentSpeed/100, 0);
    }

    public void Accelerate()
    {
        desiredSpeed = boatMaxSpeed;
        blockade = false;
        Debug.Log("Accelerating");
    }

    public void Decelerate(float speed)
    {
        desiredSpeed = speed;
        if (!blockade) {
            brakeSpot = transform.position;
            brakeSpot.y += brakeDistance;
        }

        Debug.Log("Decelerating to desired speed: " + desiredSpeed);
    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col);
        if (col.gameObject.GetComponent<Blockade>() != null)
        {
            brakeSpot = col.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            brakeSpot.y = (brakeSpot.y - ((brakeSpot.y - transform.position.y) / 2f));
            brakeSpot.x = transform.position.x;
            brakeSpot.z = transform.position.z;
            Debug.Log(brakeSpot);
            Debug.Log(transform.position);
            blockade = true;
            Decelerate(0f);
            

        }
    }
    private void ChangeSpeed()
    {
        if (desiredSpeed > currentSpeed)
        {
            currentSpeed = Mathf.Clamp(currentSpeed + (acceleration * Time.deltaTime), 0, boatMaxSpeed);
        }
        else if(desiredSpeed< currentSpeed)
        {
            currentSpeed = Mathf.Clamp(currentSpeed * (Mathf.Clamp(brakeSpot.y - transform.position.y, 0,1)), 0, boatMaxSpeed);
        }
    }
}
