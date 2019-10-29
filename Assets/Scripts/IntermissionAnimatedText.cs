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
    private int nextScene = 1;
    
    public TextMeshProUGUI intermissiontmpro;

    void Start()
    {
        StartCoroutine(AnimateText("Level Complete"));
    }

    private void Update()
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

        yield return new WaitForSeconds(1f);
        nextScene += 1;
        SceneManager.LoadScene(nextScene);

    }
}