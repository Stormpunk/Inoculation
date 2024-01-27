using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitToDesktopMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool cursorLocked = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            cursorLocked = !cursorLocked;
            if (pauseMenu.activeSelf)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
