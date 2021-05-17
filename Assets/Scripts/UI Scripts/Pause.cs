using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool paused = false;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(paused)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                paused = false;             
            }

            Time.timeScale = 0f;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                paused = true;
            }

            Time.timeScale = 1f;
        }
        pauseMenu.SetActive(paused);
    }
}
