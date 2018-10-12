using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float boatMaxSpeed;
    public float acceleration;
    public float brakeDistance;

    private float desiredSpeed;
    private float currentSpeed;
    private Vector3 brakeSpot;
    private bool blockade = false;

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

        Debug.Log("Decelerating");
    }
    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.GetComponent<Blockade>() != null)
        {
            brakeSpot = col.contacts[0].point;
            brakeSpot.x = transform.position.x;
            brakeSpot.z = 0;
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
        else
        {
            currentSpeed = Mathf.Clamp(currentSpeed * (Mathf.Clamp(brakeSpot.y - transform.position.y, 0,1)), 0, boatMaxSpeed);
        }
    }
}
