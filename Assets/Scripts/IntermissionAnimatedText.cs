using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class IntermissionAnimatedText : MonoBehaviour
{
    public Text start;
    private string str;

    
    public TextMeshProUGUI intermissiontmpro;
    public GameObject glitch;

    void Start()
    {

        StartCoroutine(AnimateText("Level Complete"));

        if (MusicFade.lastScene == 1)
        {

            var knifeThrow = Resources.Load<AudioClip>("dialogue/int1");
            AudioManager.instance.PlaySound(knifeThrow);
        }
         if (MusicFade.lastScene == 2)
        {
          var knifeThrow = Resources.Load<AudioClip>("dialogue/int3");
        AudioManager.instance.PlaySound(knifeThrow);
        }
        if (MusicFade.lastScene == 3)
        {
            var knifeThrow = Resources.Load<AudioClip>("dialogue/dialogue8_1");
            AudioManager.instance.PlaySound(knifeThrow);
        }
        if (MusicFade.lastScene == 4)
        {
            glitch.SetActive(true);
        }
    }

    void Update()
    {
        intermissiontmpro.text = str;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }


    IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        str = "";
        yield return new WaitForSeconds(2);


        while (i < strComplete.Length)
        {
            str += strComplete[i++];
            yield return new WaitForSeconds(0.1F);
        }

        yield return new WaitForSeconds(3f);
      
            StartCoroutine(AnimateText2("Constructing Simulation"));

        

    }
    IEnumerator AnimateText2(string strComplete)
    {
        int i = 0;
        str = "";
        


        while (i < strComplete.Length)
        {
            str += strComplete[i++];
            yield return new WaitForSeconds(0.1F);
        }

        yield return new WaitForSeconds(3f);
        StartCoroutine(AnimateText3("Initialization Complete"));

    }
    IEnumerator AnimateText3(string strComplete)
    {
        int i = 0;
        str = "";


        while (i < strComplete.Length)
        {
            str += strComplete[i++];
            yield return new WaitForSeconds(0.1F);
        }
        StartCoroutine(GameObject.Find("Music").gameObject.GetComponent<MusicFade>().FadeOut());
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManagerScript.nextScene);

    }
}