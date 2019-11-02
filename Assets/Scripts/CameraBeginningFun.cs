using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeginningFun : MonoBehaviour
{
    public GameObject player;

    public bool startInSun = true;
    public bool rotate = true;
    public bool rotate2 = true;
    public bool startGame = false;

    public float timer;
    public float timer2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startInSun == false)
        {
            if (transform.rotation.x >= -0.5 && rotate)
            {
                transform.Rotate(-0.5f, 0, 0, Space.Self);
                if (transform.rotation.x <= -0.5)
                {
                    rotate = false;
                }
            }
            else if (rotate == false && rotate2 == true)
            {
                timer += Time.deltaTime;
                if (timer >= 1f)
                {
                    transform.Rotate(0.5f, 0, 0, Space.Self);
                    if (transform.rotation.x >= 0.15f)
                    {
                        rotate2 = false;
                    }
                }
            }
            else if (rotate2 == false && startGame == false)
            {
                timer2 += Time.deltaTime;
                Debug.Log(timer2);
                if (timer2 >= 1f && startGame == false)
                {
                    transform.Rotate(-0.5f, 0, 0, Space.Self);
                    if (transform.rotation.x <= 0f)
                    {
                        startGame = true;
                        this.GetComponent<MouseLook>().enabled = true;
                        player.GetComponent<Controller>().enabled = true;
                        this.enabled = false;
                    }
                }
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.4f * Time.deltaTime);
            if (transform.position.y <= 26.05f)
            {
                startInSun = false;
            }
        }
    }
}
