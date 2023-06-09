using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<GameObject> activeTiles = new List<GameObject>();
    public GameObject[] tilePrefabs;
    public float tileLength = 180f;
    public int numberOfTiles = 7;
    //public int totalNumOfTiles = 8;

    int lastSpawnedObjectIndex;
    public float zSpawn = 0f;

    [SerializeField] Transform playerTransform;

    private int previousIndex;

    void Start()
    {
        for(int i = 0; i < numberOfTiles; i++) 
        {
            if (i == 0)
                SpawnTile(0);

            else
            {
                int spawnIndex = Random.Range(0, tilePrefabs.Length);

                while(spawnIndex == lastSpawnedObjectIndex) {
                    spawnIndex = Random.Range(0, tilePrefabs.Length);
                }

                lastSpawnedObjectIndex = spawnIndex;
                SpawnTile(spawnIndex);
            }

        }
         
        //playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(playerTransform.position.z - 300> zSpawn - (numberOfTiles * tileLength))
        {
            int spawnIndex = Random.Range(0, tilePrefabs.Length);

            while (spawnIndex == lastSpawnedObjectIndex)
            {
                spawnIndex = Random.Range(0, tilePrefabs.Length);
            }

            lastSpawnedObjectIndex = spawnIndex;
            SpawnTile(spawnIndex);

            DeleteTile();
        }
    }

    public void SpawnTile(int index)
    {

        GameObject go = Instantiate(tilePrefabs[index], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

}
