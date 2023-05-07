using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<GameObject> activeTiles = new List<GameObject>();
    public GameObject[] tilePrefabs;
    //[SerializeField] Transform playerTransform;
  
    public float tileLength = 180f;
    public int numberOfTiles = 7;
    //public int totalNumOfTiles = 7;

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
            SpawnTile(Random.Range(0,tilePrefabs.Length));
        }
         
        //playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(playerTransform.position.z - 300> zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(index: Random.RandomRange(0, tilePrefabs.Length));
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
