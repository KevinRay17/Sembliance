using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AnimatedText : MonoBehaviour
{
    public Text end;
    private string str;

    public TextMeshProUGUI endtmpro;

    void Start()
    {
        //Write whatever after Animate Text for next statement
        StartCoroutine(AnimateText("Simulation Complete"));
    }

    private void Update()
    {
        endtmpro.text = str;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    
    //Write new letter every .1 seconds and start next coroutine
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
        StartCoroutine(AnimateText2("Documenting Results"));

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
        StartCoroutine(AnimateText3("Thank You For Playing"));

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
        SceneManager.LoadScene(3);

    }
}