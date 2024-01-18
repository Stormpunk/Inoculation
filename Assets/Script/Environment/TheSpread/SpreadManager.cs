using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadManager : MonoBehaviour
{
    [SerializeField] private ProceduralIvy mySpreadSpawner;
    [SerializeField] private Transform killTransform;
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    [Space]
    private bool canSpawnSpread = true;

    private void Start()
    {

    }
    private void Update()
    {
        MoveToTransform();
    }


    private void MoveToTransform()
    {
        if (canSpawnSpread && Vector3.Distance(new Vector3(0, 0, this.transform.position.z), new Vector3(0, 0, mySpreadSpawner.MoveToPosition.z)) < 0.01f) 
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, mySpreadSpawner.MoveToPosition, moveSpeed);
        }

        if(Vector3.Distance(new Vector3(0,0,this.transform.position.z), new Vector3(0,0,mySpreadSpawner.MoveToPosition.z)) > 0.01f)
        {

        }
    }
}
