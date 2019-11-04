using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//level 1 instruction trigger script
//ex: if the player is within 10 units of a trigger
//a UI text will pop up saying "click to flip" or something

public class Level1Instructions : MonoBehaviour
{

    //public player gameobject assigned in inspector
    public GameObject Player;
    //trigger(click to flip to dark)
    public GameObject CLICKtrigger;
    
    //trigger to tell the player to JUMP
    public GameObject Jumptrigger;

    //UI text component
    public Text uiText;
    
    //UI text component telling the player that the space key is jump
    public Text jumpText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //hint for M1 Click:
        if (Vector3.Distance(Player.transform.position, CLICKtrigger.transform.position) < 10f)
        {
            Debug.Log("CLICKTRIGGERED");
            uiText.text = "LEFT CLICK to Flip";
        }

        //hint for SPACE Press to flip
        if (Vector3.Distance(Player.transform.position, Jumptrigger.transform.position) < 3f)
        {
            Debug.Log("Player Detected!");
            jumpText.text = "SPACE to Jump";
        }
      
    }
}
