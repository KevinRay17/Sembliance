using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseBehavior : MonoBehaviour
{
    private bool isPaused;

    public GameObject paused;
    public GameObject resume;
    public GameObject quit;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        if (Input.GetKeyDown("escape"))
        {
            Cursor.visible = true;
            ActivateMenu();
        }
    }

    public void ActivateMenu()
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        GameObject player = GameObject.FindWithTag("Player");
        camera.GetComponent<MouseLook>().enabled = false;
        player.GetComponent<CitySwap>().enabled = false;
        Time.timeScale = 0;
        AudioListener.pause = true;
        paused.SetActive(true);
        resume.SetActive(true);
        quit.SetActive(true);
    }
    
    public void DeactivateMenu()
    {
        Cursor.visible = false;
        GameObject camera = GameObject.FindWithTag("MainCamera");
        GameObject player = GameObject.FindWithTag("Player");
        Time.timeScale = 1;
        camera.GetComponent<MouseLook>().enabled = true;
        player.GetComponent<CitySwap>().enabled = true;
        AudioListener.pause = false;
        paused.SetActive(false);
        isPaused = false;
        resume.SetActive(false);
        quit.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
