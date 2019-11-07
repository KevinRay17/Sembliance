using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Deactive());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
