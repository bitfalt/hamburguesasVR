using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject objectToSpawn;

    public float spawnPosX;
    public float spawnPosY;
    public float spawnPosZ;

    // Function to spawn the object at a given position
    public void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Object to spawn is not assigned!");
        }
    }
}
