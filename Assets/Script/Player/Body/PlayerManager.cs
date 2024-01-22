using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Stats playerStats;
    [Space]
    [Header("Hazard Detection")]
    [SerializeField] private GameObject deathField;
    [SerializeField] private float safeDistance;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<Stats>();   
    }

    // Update is called once per frame
    void Update()
    {
        safeDistance = playerRb.transform.position.z - deathField.transform.position.z;
       // Debug.Log($"Player infection =  {playerStats.Infection}");
        //checks the distance between the death field (vines) and the player
        /*if(safeDistance < 0)
        {
            Debug.Log("Player is in danger");
        } */
        if (safeDistance < 0f && safeDistance > -10f)
        {
            playerStats.Infection += 1f * Time.deltaTime;
        }
        else if (safeDistance < -10f && safeDistance > -20f)
        {
            playerStats.Infection += (10f * Time.deltaTime);
        }
        else if( safeDistance < -20f && safeDistance > -50f)
        {
            playerStats.Infection += (30f * Time.deltaTime);
        }
        else if (safeDistance < -50f)
        {
            playerStats.IsAlive = false;
            Debug.Log("Player is dead");
        }
    }
}
