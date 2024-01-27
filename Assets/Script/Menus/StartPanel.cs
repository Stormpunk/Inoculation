using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public GameObject thisPanel;
    public bool isPaused = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused)
        {
            Time.timeScale = 0f;
        }
        if (Input.anyKeyDown)
        {
            thisPanel.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }
    }
}
