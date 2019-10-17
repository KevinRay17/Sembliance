using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour
{
    //Footprint gets smaller then destroys

    public AnimationCurve myTweenCurve;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroutween());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Coroutween()
    {
        float t = 0f;
        Vector3 startPos = transform.localScale;
        Vector3 endPos = new Vector3(0,0,0);
        yield return  new WaitForSeconds(.15f);
        while (t < 1f)
        {
            transform.localScale = Vector3.SlerpUnclamped(startPos, endPos, myTweenCurve.Evaluate(t));
            t += Time.deltaTime/4;
            yield return 0;
        }
        Destroy(gameObject);
    }
}
