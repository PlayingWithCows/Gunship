using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public Transform target;
    public float range;
    public float reloadTime;
    public GameObject projectile;
    

    private Collider[] hitColliders;
    private List<Destructible> destru = new List<Destructible>();
    private float timeLastFired;

    // Use this for initialization
    void Start () {
        timeLastFired = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        
        CheckIfTargetIsStillInRange();
        if (target == null)
        {
            FindNextTarget();
        }

        if (target != null)
        {
            if (Time.time >= timeLastFired + reloadTime)
            {
                timeLastFired = Time.time;
                ShootAtTarget(target);
            }
        }
    }

    private void CheckIfTargetIsStillInRange()
    {
        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) > range)
            {
                target = null;
            }
        }
    }

    private void ShootAtTarget(Transform target)
    {
    
        if (projectile != null)
        {
            if(projectile.GetComponent<Projectile>() != null)
            {
                GameObject shot = Instantiate(projectile, transform.position, Quaternion.identity, transform);
                Projectile proj = shot.GetComponent<Projectile>();
                proj.LaunchShot(target);
            }
        }
    }

    private void FindNextTarget()
    {
        hitColliders = Physics.OverlapSphere(transform.position, range);
       
        foreach (Collider col in hitColliders)
        {
            if (col.transform.GetComponent<Destructible>() != null)
            {

                destru.Add(col.transform.GetComponent<Destructible>());
            }
            
        }
        float objectDistance = range+1;
        int objectIndex = 0;
        for (int i = 0; i < destru.Count; i++)
        {
            float distance = Vector3.Distance(destru[i].transform.position, transform.position);
            if (distance <= range && distance< objectDistance)
            {
                objectIndex = i;
                objectDistance = distance;
            }

        }
        if (objectDistance > range)
        {
            target = null;
        }
        else { target = destru[objectIndex].transform; }


        destru.Clear();
    }
}
