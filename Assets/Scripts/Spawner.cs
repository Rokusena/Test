using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 3f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
           
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);

           
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
