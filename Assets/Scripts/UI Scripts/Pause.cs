using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    bool paused = false;

    public GameObject pauseMenu;
    public UnityEvent onPaused;
    public UnityEvent onUnpaused;

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
                onUnpaused.Invoke();
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
                onPaused.Invoke();
            }

            Time.timeScale = 1f;
        }
        pauseMenu.SetActive(paused);
    }
}
