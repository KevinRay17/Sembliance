using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public static int nextScene;
    //nextScene = SceneManager.GetActiveScene().buildIndex +1;
    //SceneManager.LoadScene(nextScene);
    
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.transform.gameObject);
        //gets current scene
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
       // SceneManager.LoadScene(nextScene);
    }

    void Update()
    {

    }

}
