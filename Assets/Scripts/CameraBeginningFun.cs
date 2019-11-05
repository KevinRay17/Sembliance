using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeginningFun : MonoBehaviour
{
    public GameObject player;
    private GameObject canvas;

    public static bool runCinematic = true;
    public bool startInSun = true;
    public bool rotate = true;
    public bool rotate2 = true;
    public bool startGame;
    private float desiredRot;

    public float timer;
    public float timer2;
    // Start is called before the first frame update
    void Start()
    {
        desiredRot = transform.eulerAngles.z;
        canvas = GameObject.FindGameObjectWithTag("PlayerCanvas");
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (runCinematic == true)
        {
            startGame = false;
            if (startInSun == false && rotate == true)
            {
                var desiredRotQ = Quaternion.Euler(-50f, transform.eulerAngles.y, transform.eulerAngles.z);
                transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * 1f);
                Debug.Log(transform.eulerAngles.x);
                if (transform.eulerAngles.x <= 312f)
                {
                    rotate = false;
                }
            }
            else if (startInSun == false && rotate == false)
            {
                var desiredRotQ2 = Quaternion.Euler( 0f, transform.eulerAngles.y, transform.eulerAngles.z);
                transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ2, Time.deltaTime * 1f);
                if (transform.eulerAngles.x >= 359.5f)
                {
                    startGame = true;
                    this.GetComponent<MouseLook>().enabled = true;
                    player.GetComponent<Controller>().enabled = true;
                    player.GetComponent<CitySwap>().enabled = true;
                    canvas.SetActive(true);
                    runCinematic = false;
                    this.enabled = false;
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
        else
        {
            startGame = true;
            transform.position = player.transform.position;
            this.GetComponent<MouseLook>().enabled = true;
            player.GetComponent<Controller>().enabled = true;
            player.GetComponent<CitySwap>().enabled = true;
            canvas.SetActive(true);
            this.enabled = false;
        }
        
    }
}
