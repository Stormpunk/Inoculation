using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrySpawnTrigger : MonoBehaviour
{
    [SerializeField] 
    private RoomGenerator roomGenerator;
    [SerializeField]
    private TemplateHolder thisRoom;

    [SerializeField] private Transform roomSpawnLaser;
    private void Start()
    { 
        thisRoom = GetComponentInChildren<TemplateHolder>();
        roomGenerator = GameObject.FindWithTag("Gamemanager").gameObject.GetComponent<RoomGenerator>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(roomSpawnLaser.transform.position, roomSpawnLaser.transform.TransformDirection(Vector3.right), out hit) && hit.transform.tag == "Player" /*|| Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit) && hit.transform.tag == "Player"*/) 
        {
            if (!thisRoom.RoomIsSPawn)
            {
                roomGenerator.SpawnPrefab(thisRoom.thisExitPoint.transform);
                thisRoom.RoomIsSPawn = true;
            }
           
        }
    }
}
