using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicFade : MonoBehaviour
{
    AudioSource source;
    public static int lastScene;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(FadeIn());
        lastScene = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator FadeIn()
    {
       source.volume = 0;
        while (source.volume < 1)
        {
            source.volume += Time.deltaTime/2;
            yield return 0;
        }
        
    }

    public IEnumerator FadeOut()
    {
      float Volume =  source.volume;
        while (source.volume > 0)
        {
      

            source.volume -= Time.deltaTime/1.5f;
            yield return 0;
        }
        Destroy(gameObject);
    }
}
