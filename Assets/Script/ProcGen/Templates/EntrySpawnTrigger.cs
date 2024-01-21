using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrySpawnTrigger : MonoBehaviour
{
    [SerializeField] 
    private RoomGenerator roomGenerator;
    [SerializeField]
    private TemplateHolder thisRoom;

    private void Start()
    { 
        thisRoom = GetComponentInChildren<TemplateHolder>();
        roomGenerator = GameObject.FindWithTag("Gamemanager").gameObject.GetComponent<RoomGenerator>();
    }

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit) && hit.transform.tag == "Player" || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit) && hit.transform.tag == "Player") 
        {
            if (!thisRoom.RoomIsSPawn)
            {
                roomGenerator.SpawnPrefab(thisRoom.thisExitPoint.transform);
                thisRoom.RoomIsSPawn = true;
            }
        }
    }
}
