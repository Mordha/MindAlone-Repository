using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyStats : MonoBehaviour
{
    public int life;
    public GameObject enemyFather;
    public Transform spawnUbication;
    public GameObject[] objectsToSpawn;
    public float timeToDie = 0.2f;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            life -= Bullet.bulletDamage;
            Debug.Log("ha colisinado");
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            timeToDie -= Time.deltaTime;
            SpawnObjects();
        }
    }

    private void SpawnObjects()
    {
        int n = Random.Range(0, objectsToSpawn.Length);
        Instantiate(objectsToSpawn[n], spawnUbication.position, objectsToSpawn[n].transform.rotation);
        Destroy(enemyFather.gameObject);
    }
}
