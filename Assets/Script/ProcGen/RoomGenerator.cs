using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> roomPrefabs = new List<GameObject>();
    //all the potential templates that are spawned
    private Transform nextPrefabPosition;
    public int roomLimit = 3;
    public int spawnedRooms = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CollectNPP()
    {
        //nextPrefabPosition = GameObject.FindGameObjectWithTag("NextPosition").transform;
    }
    public void SpawnPrefab(Transform position)
    {
        GameObject newRoom = GameObject.Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)]);
        newRoom.transform.position = position.position;
        spawnedRooms++;
    }
}
