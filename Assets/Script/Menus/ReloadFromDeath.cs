using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadFromDeath : MonoBehaviour
{
    public GameObject deathPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(deathPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
            Debug.Log("reloading");
        }
    }
}
