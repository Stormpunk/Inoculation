using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gManager;
    [Space]
    [SerializeField]
    private GameObject deathPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gManager.player.GetComponent<Stats>().IsAlive == false)
        {
            PlayerDeath();
        }
    }
   void PlayerDeath()
    {
        deathPanel.SetActive(true);
        gManager.player.GetComponent<Movement>().enabled = false;
    }
}
