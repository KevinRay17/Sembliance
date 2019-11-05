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


    void Start()
    {
        changeImages();
    }
    private void Update()
    {
        changeImages();
    }

    void changeImages() //attach to event trigger
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
}
