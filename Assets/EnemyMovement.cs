using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Player player;
    public float speed;
    public float turnSpeed;

    public Vector3 destination;
    private float currentSpeed;


    private void Start()
    {
        Turn();
        Move();
    }

    private void Turn()
    {
        
    }

    private void Move()
    {
        
        transform.Translate(0, currentSpeed/100, 0);
    }
}
