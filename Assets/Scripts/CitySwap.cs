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
                Physics.gravity = new Vector3(0, Physics.gravity.y * -1, 0);
                OnWhite = !OnWhite;
                StartCoroutine(PARTICLES());
                //if (Controller.instance.grounded)
                //transform.position = hit.point;
                //else
                //{
                    if (OnWhite)
                    transform.position = hit.point + new Vector3(0, 1.5f, 0);
                    else
                    {
                        transform.position = hit.point + new Vector3(0, -1.5f, 0);
                  //  }
                }
                
            }
        }

        //if (!OnWhite)
        //{
          //  gameObject.transform.localRotation = new Quaternion(gameObject.transform.localRotation.x,
            //    gameObject.transform.localRotation.y,180,gameObject.transform.localRotation.w);
        //}
        Debug.Log(Physics.gravity);
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
