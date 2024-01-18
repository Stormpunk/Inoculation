using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrySpawnTrigger : MonoBehaviour
{
    [SerializeField] 
    private RoomGenerator roomGenerator;
    private TemplateHolder thisRoom;

    private void Start()
    { 
        thisRoom = GetComponentInChildren<TemplateHolder>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            thisRoom.SpawnNewPrefab();
        }
    }
}
