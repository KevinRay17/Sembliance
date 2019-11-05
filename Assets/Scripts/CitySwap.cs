using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySwap : MonoBehaviour
{
    public static bool OnWhite = true;
    int layerMask = 1 << 10;

    public ParticleSystem PS;

    public Material WhiteMat;

    public Material BlackMat;
    // Start is called before the first frame update
    void Start()
    {
        OnWhite = true;
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //Teleport, raycast direct above and switch sides but player moves right above ground to help maintain momentum without grounding
        if (Input.GetMouseButtonDown(0))
        {
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity,
                layerMask))
            {
                Physics.gravity = Physics.gravity * -1;
                OnWhite = !OnWhite;
                StartCoroutine(PARTICLES());
               
                    if (OnWhite)
                    transform.position = hit.point + new Vector3(0, 1.5f, 0);
                    else
                    {
                        transform.position = hit.point + new Vector3(0, -1.5f, 0);
                    }
                

                if (Controller.instance.onMove)
                {
                    Controller.instance.onMove = false;
                    Controller.instance.onMoveBlack = true;
                } else if (Controller.instance.onMoveBlack)
                {
                    Controller.instance.onMove = true;
                    Controller.instance.onMoveBlack = false;
                }
              
                
            }
            if (hit.transform == null)
            {
                Debug.Log("NUDLADNCL");
            }


        }

        //if (!OnWhite)
        //{
          //  gameObject.transform.localRotation = new Quaternion(gameObject.transform.localRotation.x,
            //    gameObject.transform.localRotation.y,180,gameObject.transform.localRotation.w);
        //}
        //Debug.Log(Physics.gravity);
    }

    IEnumerator PARTICLES()
    {
        yield return new WaitForSeconds(.1f);
        
        if (OnWhite)
        {
            PS.gameObject.GetComponent<ParticleSystemRenderer>().material = BlackMat;

        }
        else
        {
            PS.gameObject.GetComponent<ParticleSystemRenderer>().material = WhiteMat;
        }
        PS.Emit(60);
        
    }
}
