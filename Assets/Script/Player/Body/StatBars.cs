using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBars : MonoBehaviour
{
    [Header("Bar Images")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image fatigueBar;
    [SerializeField] private Image infectionBar;
    [Header("GameManager and Player")]
    [SerializeField] private GameManager gManager;
    [Space]
    [SerializeField] private Stats pStats;
    // Start is called before the first frame update
    void Start()
    {
        pStats = gManager.player.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = pStats.Health / 100;
        fatigueBar.fillAmount = 1 - (pStats.Fatigue / 100);
        infectionBar.fillAmount = pStats.Infection / 100;
    }
}
