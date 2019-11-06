using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipUI : MonoBehaviour
{
    //make the UI sprite of the arrow switch when in the correct state
   //or if the player cannot jump the red versions appear

    public Sprite blackArrow;

    public Sprite whiteArrow;

    public Sprite REDblackArrow;

    public Sprite REDwhiteArrow;

    public AnimationCurve myTweenCurve;

    public static FlipUI instance;
    public bool failing;
    

    void Start()
    {
        instance = this;
        changeImages();
    }
    private void Update()
    {
    }

    public void changeImages() //attach to event trigger
    {
        if (CitySwap.OnWhite == true)
        {
            gameObject.GetComponent<Image>().sprite = blackArrow;
        }
        if(CitySwap.OnWhite == false)
        {
            Debug.Log("On black has returned true");
           gameObject.GetComponent<Image>().sprite = whiteArrow;

        }

        
        

     
    }

   public IEnumerator failFlip()
   {
       failing = true;
        if (CitySwap.OnWhite == true && CitySwap.flipPossible == false)
        {
            gameObject.GetComponent<Image>().sprite = REDblackArrow;
        }
       else if (CitySwap.OnWhite == false && CitySwap.flipPossible == false)
        {
            gameObject.GetComponent<Image>().sprite = REDwhiteArrow;

        }
        float t = 0; //time value
        Vector3 startScale = gameObject.transform.localScale;
        Vector3 endScale = gameObject.transform.localScale + new Vector3(1, 1, 1);
        while (t < 1)
        {
            gameObject.transform.localScale = Vector3.LerpUnclamped(startScale, endScale, myTweenCurve.Evaluate(t));
            t += Time.deltaTime *6;
            yield return 0;
            
        }

        transform.localScale = startScale;
       if (CitySwap.OnWhite == true)
       {
           gameObject.GetComponent<Image>().sprite = blackArrow;
       }
       if(CitySwap.OnWhite == false)
       {
           Debug.Log("On black has returned true");
           gameObject.GetComponent<Image>().sprite = whiteArrow;

       }
       failing = false;
   }
}
