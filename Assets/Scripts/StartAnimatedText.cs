using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class StartAnimatedText : MonoBehaviour
{
    public Text start;
    private string str;
    
    public TextMeshProUGUI starttmpro;

    void Start()
    {
        StartCoroutine(AnimateText("Sembliance"));
    }

    private void Update()
    {
        starttmpro.text = str;
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
        var knifeThrow = Resources.Load<AudioClip>("dialogue/dialogue1");
        AudioManager.instance.PlaySound(knifeThrow);

        while (i < strComplete.Length)
        {
            str += strComplete[i++];
            yield return new WaitForSeconds(0.1F);
        }

        yield return new WaitForSeconds(3.5f);
        StartCoroutine(AnimateText2("Constructing Simulation..."));

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

        yield return new WaitForSeconds(3.5f);
        StartCoroutine(AnimateText3("Welcome"));

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
        
        SceneManager.LoadScene(1);

    }
}