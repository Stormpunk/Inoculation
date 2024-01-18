using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateHolder : MonoBehaviour
{
    [SerializeField]
    //private List<Transform> nextPositionTransform = new List<Transform>();
    public Transform nextPosition;
    [SerializeField]
    public Transform lastPositionTransform;
    [SerializeField]
    private RoomGenerator roomGenerator;
    private bool roomIsSpawn;
    public void SpawnNewPrefab()
    {
        roomGenerator.SpawnPrefab(nextPosition);
        roomIsSpawn = true;
    }
    private void Start()
    {
        roomGenerator = GameObject.Find("GameManager").GetComponent<RoomGenerator>();
        /*if (!roomIsSpawn && roomGenerator.spawnedRooms < roomGenerator.roomLimit)
        {
            SpawnNewPrefab();
        } */
    }
}
