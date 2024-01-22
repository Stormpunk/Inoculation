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
    public int roomOrder = 2;
    //the game starts with 2 rooms spawned so the first instantiated room will be the 3rd room
    [SerializeField]
    public List<GameObject> allRooms = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPrefab(Transform position)
    {
        GameObject newRoom = GameObject.Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)]);
        //grabs a room prefab to instantiate
        newRoom.transform.position = position.position;
        //spawns the new object at the end of the corridor
        newRoom.GetComponentInChildren<TemplateHolder>().RoomValue = roomOrder;
        allRooms.Add(newRoom);
        //sets the int so we know when to remove the room / everything inside
        spawnedRooms++;
        roomOrder++;
        foreach (GameObject room in allRooms)
        {
            room.GetComponentInChildren<TemplateHolder>().RoomDestroyCount++;
            //increase the instantiated 
        }
    }
    /*public void PoolPrefab(Transform position)
    {
        GameObject pooledRoom = allRooms[roomOrder];
        pooledRoom.transform.position = position.position;
        if(roomOrder < allRooms.Count - 2)
        {
            roomOrder = 2;
        }
        roomOrder++;
    }*/
}
