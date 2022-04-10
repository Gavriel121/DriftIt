using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{

    public GameObject box;
    public GameObject block;

    public Transform[] spawnPoints;

    public GameObject SpawnEffect;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            Destroy(gameObject);
            Spawnbox();
            SpawnBlock();
            
        }

        void Spawnbox()
        {
            Instantiate(SpawnEffect, transform.position, SpawnEffect.transform.rotation);

            int spawnPointX = Random.Range(-12, 12);
            int spawnPointZ = Random.Range(-12, 12);
            int spawnPointY = Random.Range(1, 1);

            Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);
            Instantiate(box, spawnPosition, Quaternion.identity);
        }

        void SpawnBlock()
        {
            int spawnPointX = Random.Range(-12, 12);
            int spawnPointZ = Random.Range(-12, 12);
            float spawnPointY = Random.Range(10, 10);

            Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);
            Instantiate(block, spawnPosition, Quaternion.identity);
        }

    }
}
