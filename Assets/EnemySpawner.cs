using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Vector3 distanceToPlayer;
    public Player player;
    public bool triggered;
    public GameObject[] shipsToSpawn;
    public int spawnIndex = 0;
    public int enemiesToSpawn = 0;
    public float spawnRate = 0.5f;
    private Vector3 spawnPos;
    private float timeLastSpawned = 0;
   

    // Use this for initialization
    void Start () {
        enemiesToSpawn = shipsToSpawn.Length;
    }
	
	// Update is called once per frame
	void Update () {
        if (triggered && timeLastSpawned + spawnRate < Time.time && spawnIndex < enemiesToSpawn )
        {
            SpawnEnemy();
        }
	}
    void SpawnEnemy()
    {
       spawnPos = player.transform.position + distanceToPlayer;
       Instantiate(shipsToSpawn[spawnIndex], spawnPos, Quaternion.identity, transform);
       spawnIndex++;


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Player>() != null)
        {
            player = col.GetComponent<Player>();
            triggered = true;
            distanceToPlayer = transform.position - col.transform.position;
        }
    }
}
