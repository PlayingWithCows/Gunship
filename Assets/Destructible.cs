using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public int maxHealth;
    public int coinValue;
    public List<GameObject> loot;
    public GameObject destroyParticles;

    private int health;
	// Use this for initialization
	void Start () {
        health = maxHealth;
    }
	

    public void GetHit(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);
        if (health <= 0)
        {
            foreach (GameObject item in loot)
            {
                Instantiate(item, transform.position + new Vector3(Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1)), Quaternion.identity);
            }
            GameObject particles = Instantiate(destroyParticles, transform.position, Quaternion.identity, transform);
            Destroy(particles, 2f);
            Destroy(gameObject,3f);
        }
    }
}
