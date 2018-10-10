using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float boatMaxSpeed;
    public float acceleration;
    public float deceleration;

    private float desiredSpeed;
    private float currentSpeed;

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
    }

    public void Decelerate()
    {
        desiredSpeed = 0;
    }

    private void ChangeSpeed()
    {
        if (desiredSpeed > currentSpeed)
        {
            currentSpeed = Mathf.Clamp(currentSpeed + (acceleration * Time.deltaTime), 0, boatMaxSpeed);
        }
        else
        {
            currentSpeed = Mathf.Clamp(currentSpeed - (deceleration * Time.deltaTime), 0, boatMaxSpeed);
        }
    }
}
