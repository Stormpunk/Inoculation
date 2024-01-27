using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGenerator : MonoBehaviour
{
    public static RandomItemGenerator Instance;
    [SerializeField] private Transform itemSpawnDist, itemSpawnRangeMin, itemSpawnRangeMax;
    public GameObject[] itemList;
    public GameObject player;
    public float offset;
    [SerializeField]
    private float timeBetweenSpawns, maxTimeBetweenSpawns;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        itemSpawnDist = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.z = player.transform.position.z + 10;
        transform.position = newPosition;
        timeBetweenSpawns -= Time.deltaTime;
        if(timeBetweenSpawns <= 0 )
        {
            SpawnItem();
            timeBetweenSpawns = maxTimeBetweenSpawns;
        }
    }
    public void SpawnItem()
    {
        bool canSpawn = (Random.value > 0.5f);
        if(canSpawn )
        {
            int i = Random.Range(0, itemList.Length);
            GameObject spawnedObject = Instantiate(itemList[i]);
            //z = itemspawndist
            //x is random between item min and item max

            spawnedObject.transform.position = new Vector3(Random.Range(itemSpawnRangeMin.position.x, itemSpawnRangeMax.position.x), itemSpawnDist.transform.position.y, itemSpawnDist.position.z);
            Debug.Log("SpawningItem");
        }
        else
        {
            Debug.Log("Not Spawning item");
        }
    }
}
