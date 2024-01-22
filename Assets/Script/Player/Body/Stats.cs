using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    #region Stats
    [Header("Health")]
    [SerializeField] private float health;
    public float Health
    {
        get { return health; }
        set { health = value; }
    }
    [SerializeField] private float maxHealth = 100f;
    [Space]
    [Header("Other")]
    [SerializeField] private float infection;
    public float Infection
    {
        get { return infection; }
        set { infection = value; }
    }
    [SerializeField] private float fatigue;
    public float Fatigue
    {
        get { return fatigue; }
        set { fatigue = value; }
    }
    public float MaxFatigue = 100;
    //if the player reaches 100 fatigue they will no longer be able to operate
    #endregion
    #region Bools
    [Space]
    [Header("Status Bools")]
   [SerializeField] private bool isAlive = true;
    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive  = value;}
    }
    #endregion 

    private void Start()
    {
        #region Initialize Stats
        health = maxHealth;

        infection = 0;
        #endregion
    }
}
