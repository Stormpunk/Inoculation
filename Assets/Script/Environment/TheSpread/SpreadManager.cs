using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadManager : MonoBehaviour
{
    [SerializeField] private ProceduralIvy mySpreadSpawner;
    [SerializeField] private Transform killTransform;
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float spawnDelay;
    [SerializeField] private bool readyToSpawn = false;
    [SerializeField] private int floatingMesh;
    //how many instances of the spread exists that hasn't been merged into a mesh

    private void Start()
    {
        spawnDelay = 2f;
    }
    private void Update()
    {
        //StartCoroutine(MoveToTransform());
        if(readyToSpawn == true)
        {
            readyToSpawn = false;
            StartCoroutine(MoveToTransform());
        } 
        if(floatingMesh > 3)
        {
            mySpreadSpawner.combineAndClear();
            floatingMesh = 0;
        }
    }


    IEnumerator MoveToTransform()
    {
        mySpreadSpawner.CreateFromPoint(this.transform);
        floatingMesh++;
        //creates a vine and increases the floatingMesh value
        while (spawnDelay > 0)
        {
            spawnDelay -=  Time.deltaTime;
            Vector3 targetDirection = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 5);
            this.transform.position += new Vector3(0, 0, 1) * (Time.deltaTime * moveSpeed);
            //   = Vector3.MoveTowards(this.transform.position, targetDirection, moveSpeed);
            //Debug.Log("Moving Towards " + mySpreadSpawner.MoveToPosition.ToString());
            yield return null;
        }
        Debug.Log("iF you see me multiple times a second there's aproblem");
        spawnDelay = 2;
        readyToSpawn = true;

        //mySpreadSpawner.hasSpawned = false;
        
        /*
        if(mySpreadSpawner.hasSpawned = false && Vector3.Distance(new Vector3(0,0,this.transform.position.z), new Vector3(0,0,mySpreadSpawner.MoveToPosition.z)) > 0.01f)
        {
            Debug.Log("Boop");
        } */
    }
}
