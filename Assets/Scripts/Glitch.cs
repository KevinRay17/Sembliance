using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    public Material Disappear;
    public Material Glitched;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GlitchWait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GlitchWait()
    {
        yield return new WaitForSeconds(10);
        gameObject.GetComponent<Renderer>().material = Glitched;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Renderer>().material = Disappear;
        StartCoroutine(GlitchWait());

    }
}
