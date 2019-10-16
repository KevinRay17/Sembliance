using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScaler : MonoBehaviour
{
    public float Speed;

    private bool collided;
    int layerMask = 1 << 10;

    private GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        Speed = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.instance.started)
        {
            if (!collided)
            {
                gameObject.transform.localScale += new Vector3(0, .001f * Speed * Time.deltaTime, 0);
                if (Speed > 5)
                    Speed -= Time.deltaTime;
            }
        }

        RaycastHit hit;
        Debug.DrawRay(child.transform.position, transform.TransformDirection(Vector3.up) * transform.localScale.y*5,
            Color.yellow);
        
        if (Physics.Raycast(child.transform.position, transform.TransformDirection(Vector3.up), out hit, (transform.localScale.y *5), layerMask) 
            && gameObject.CompareTag("CityWhite"))
        {
            collided = true;
        }
        if (Physics.Raycast(child.transform.position, transform.TransformDirection(Vector3.down), out hit, (transform.localScale.y *5), layerMask) 
            && gameObject.CompareTag("CityBlack"))
        {
            collided = true;
        }
    }

 
}