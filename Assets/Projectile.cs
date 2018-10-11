using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    public int damage;
    public float speed;
    public bool splash;
    public int splashDamage;
    public float splashRadius;
    public GameObject explosion;

    private Transform target;
    private Vector3 lastTargetPos;
    private bool launched = false;

    private void Update()
    {
        if (launched && target != null)
        {
            lastTargetPos = target.position;
            MoveToTarget();
            ProximityCheck();
        }
        if (launched && target == null)
        {
            MoveToTarget();
            ProximityCheck();
        }
    }

    private void ProximityCheck()
    {
        if (Vector3.Distance(transform.position, lastTargetPos) < 0.2f)
        {
          
                DealDamage();
            
        }
    }

    private void MoveToTarget()
    {
        transform.LookAt(lastTargetPos);
        transform.Translate(0, 0, speed * Time.deltaTime);

    }

    private void DealDamage()
    {
        if(target != null)
        {
            target.GetComponent<Destructible>().GetHit(damage);
        }
        
        if(explosion != null)
        {
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp, 2f);
        }
        if (splash)
        {
            DealSplashDamage();
        }
        Destroy(gameObject);
    }

    private void DealSplashDamage()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, splashRadius / 100);
        foreach (Collider col in colls)
        {
            if(col.transform.GetComponent<Destructible>() != null) { 
            col.transform.GetComponent<Destructible>().GetHit(splashDamage);
            }
        }
    }

    public void LaunchShot(Transform ShotTarget)
    {
        target = ShotTarget;
        launched = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Destructible>() != null)
        {
            target = collision.collider.transform;
            DealDamage();
        }
    }
}
