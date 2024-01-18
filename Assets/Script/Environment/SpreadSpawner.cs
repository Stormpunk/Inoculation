using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadSpawner : MonoBehaviour
{
    private GameObject player;
    public bool hasSpawned = false;
    private bool isFullyGrown = false;
    [SerializeField] private Material myVine;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(hasSpawned == false)
        {
            isFullyGrown = false;
            //if the spawner hasn't spawned an object yet, reset the growth shader
        }
        if(hasSpawned != false)
        {
            //StartCoroutine(Grow(1));
        }   
        if (hasSpawned == true && isFullyGrown == false)
        {
            //Vector3.MoveTowards(this.transform.position, player.transform.position, 1f);
        }
    }
    
   /* private IEnumerator Grow(float growSpeed)
    {
        float myGrowthValue = myVine.GetFloat("Grow");
        if (myGrowthValue > 1)
        {
            while(myGrowthValue < 1)
            {
                myGrowthValue += 1 / (Time.deltaTime);
                myVine.SetFloat("Grow", myGrowthValue);
                yield return new WaitForSeconds(10);
                isFullyGrown = true;
            }
        }
        else
        {
            while(myGrowthValue < 1)
            {
                myGrowthValue += 1 / (Time.deltaTime);
                myVine.SetFloat("Grow", myGrowthValue);
                yield return new WaitForSeconds(10);
                isFullyGrown = true;
            }
        }
    } */
}
