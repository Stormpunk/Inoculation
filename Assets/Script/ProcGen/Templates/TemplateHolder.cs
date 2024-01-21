using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateHolder : MonoBehaviour
{
    [SerializeField]
    public ExitPoint thisExitPoint;
    [SerializeField]
    private RoomGenerator roomGenerator;
    [SerializeField]
    private bool roomIsSpawn;
    public bool RoomIsSPawn
    {
        get { return roomIsSpawn; }
        set { roomIsSpawn = value; }
    }
    private void Start()
    {
        roomGenerator = GameObject.Find("GameManager").GetComponent<RoomGenerator>();
        thisExitPoint = GetComponentInChildren<ExitPoint>();
        /*if (!roomIsSpawn && roomGenerator.spawnedRooms < roomGenerator.roomLimit)
        {
            SpawnNewPrefab();
        } */
    }

}
