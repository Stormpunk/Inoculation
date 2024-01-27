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
        #region Handle Infection
        if (playerStats.Health > 100)
        {
            playerStats.Health = 100;
        }
        switch (safeDistance)
        {
            case float f when f < 0.0f && f > -10f:
                playerStats.Infection += 1f * Time.deltaTime;
                break;
            case float f when f < -10f && f > -20f:
                playerStats.Infection += (10f * Time.deltaTime);
                break;
            case float f when f < -20f && f > -49f:
                playerStats.Infection += (30f * Time.deltaTime);
                break;
            case float f when f < -50:

                playerStats.IsAlive = false;
                Debug.Log("Player is dead");
                break;
        }
        switch (playerStats.Infection)
        {
            case float i when i > 10f:
                playerStats.Health -= 1 * Time.deltaTime;
                break;
            case float i when i > 50f:
                playerStats.Health -= 5 * Time.deltaTime;
                break;
            case float i when i > 75f:
                playerStats.Health -= 10 * Time.deltaTime;
                break;
        }
        if(playerStats.Health <= 0 || playerStats.Infection >= 100)
        {
            playerStats.IsAlive = false;
        }

        #endregion
        #region Player Healing and Stamina Regeneration
        if (Input.GetKeyDown(KeyCode.Alpha1) && TestInventory.instance.HealthPack > 0)
        {
            TestInventory.instance.HealthPack--;
            if(playerStats.Health < 100)
            {
                playerStats.Health += 20;
            }
            //uses a healthpack and heals the player if their health is less than 100
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && TestInventory.instance.Antidote > 0)
        {
            TestInventory.instance.Antidote--;
            if(playerStats.Infection > 0)
            {
                playerStats.Infection -= 10;
            }
            Debug.Log("2 pressed");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && TestInventory.instance.StimGood > 0)
        {
            TestInventory.instance.StimGood--;
            if(playerStats.Fatigue < 100)
            {
                playerStats.Fatigue -= 20;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && TestInventory.instance.StimBad > 0)
        {
            TestInventory.instance.StimBad--;   
            if(playerStats.Fatigue < 100)
            {
                playerStats.Fatigue -= 20;
                playerStats.Infection += 10;
            }
        }
        #endregion
    }
}
