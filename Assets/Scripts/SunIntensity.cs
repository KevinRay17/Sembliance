using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SunIntensity : MonoBehaviour
{
    //Sun intensity wont change much to negate fog
    
    
    public GameObject player;

    private Renderer mat;

    private Color brightness;

    private float distance;
    private float near = 75.0f;
    private float far = 390.0f;
    private float high = 27.0f;
    private float low = 7.0f;
    private float intensity;
    private int nextScene;
    
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>();
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
       // Debug.Log(distance);
        //if beyond max distance set to highest. if below min distance stop changing intensity
        if (distance < near)
            intensity = low;
        else if (distance > far)
            intensity = high;
        else
            intensity = ((distance - near) / (far / (high - low))) + low;

        Color color = mat.material.GetColor("_Color");
        color *= Mathf.Pow(2.0F, intensity);
        mat.material.SetColor("_EmissionColor", color);
        
        //mat.material.SetColor("_EmissionColor", new Color(intensity,intensity,intensity, 1));
       // mat.material.EnableKeyword("_EMISSION");
        //Debug.Log(intensity);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (SceneManagerScript.nextScene == 8)
        {
            SceneManager.LoadScene(8);
        } else {
            SceneManager.LoadScene(9);
            SceneManagerScript.nextScene += 1;
        
            }

    }
//IEnumerator FadeTime()
  //  {
    //    StartCoroutine(GameObject.Find("Music").gameObject.GetComponent<MusicFade>().FadeOut());
      //  yield return new WaitForSeconds(1.5f);
        //SceneManager.LoadScene(9);
        //SceneManagerScript.nextScene += 1;
    //}
}
