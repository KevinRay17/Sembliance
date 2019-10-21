using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    public float speed = 10.0F;
    //public Text pointText;
    //public int points;
    int layerMask = 1 << 10;
    public bool grounded = true;
    private bool jumpWaited = true;

    public GameObject LeftW;
    public GameObject LeftB;
    public GameObject RightW;
    public GameObject RightB;

    private Rigidbody rb;

    private bool gravChanged = false;

    public bool started = false;
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        //points = 0;
        //pointText.text = "Points:" + points.ToString ();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
        //if (CitySwap.OnWhite)
        transform.Translate(strafe, 0, translation);
        
        //else
        //{
          //  transform.Translate(strafe, 0, -translation);  
        //}

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            if (CitySwap.OnWhite)
            rb.AddForce(new Vector3(0,7f,0), ForceMode.Impulse);
            else
            {
                rb.AddForce(new Vector3(0,-7f,0), ForceMode.Impulse);
            }
            grounded = false;
            jumpWaited = false;
            StartCoroutine(JumpWait());
        }
        
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity)){

           if (hit.transform.gameObject.CompareTag("GravTile") && !gravChanged)
            {
                Physics.gravity *= 2f;
                gravChanged = true;
            }

            if (!hit.transform.gameObject.CompareTag("GravTile") && gravChanged)
            {
                Physics.gravity /= 2f;
                gravChanged = false;
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit,
                10))
        {
          
        }
        else
        {
            if (!started)
            {
                started = true;
            }
        }



        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (transform.localScale.y + .1f)) && hit.transform.gameObject.CompareTag("SpeedTile"))
        {
            speed = 15;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (transform.localScale.y + .1f)) && !hit.transform.gameObject.CompareTag("SpeedTile"))
        {
            speed = 5;
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (transform.localScale.y + .1f), layerMask) && jumpWaited && !grounded)
        {
           // StartCoroutine(PlaceFeet());
            grounded = true;
        }

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator JumpWait()
    {
     yield return new WaitForSeconds(.25f);
        jumpWaited = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
           Restart();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (grounded)
        {
            if (CitySwap.OnWhite && other.gameObject.CompareTag("CityBlack"))
            {
                Restart();
            }
            else if (!CitySwap.OnWhite && other.gameObject.CompareTag("CityWhite"))
            {
                Restart();
            }
        }
    }

    void Restart()
    {
        CitySwap.OnWhite = true;
        if (Physics.gravity.y > 0)
        {
            Physics.gravity = new Vector3(0,Physics.gravity.y * -1,0);
        }
        Application.LoadLevel(Application.loadedLevel);
    }

    /*IEnumerator PlaceFeet()
    {
        int foot = 1;
        yield return 0;
        Debug.Log("here");
        while (grounded)
        {
            Debug.Log("nowhere");
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit,
                (transform.localScale.y + .1f), layerMask))
            {
                if (!CitySwap.OnWhite)
                {
                    if (foot == 1)
                    {
                        Instantiate(LeftW, hit.point - new Vector3(.5f, 0, 0), new Quaternion(0,0,0,0));
                        foot *= -1;
                    }
                    else
                    {
                        Instantiate(RightW, hit.point + new Vector3(.5f,0,0),new Quaternion(45,0,0,0));
                        foot *= -1;
                    }
                }
                else
                {
                    if (foot == 1)
                    {
                        Instantiate(LeftB, hit.point - new Vector3(.5f, -.015f, 0), Quaternion.Euler(90,0,0));
                        foot *= -1;
                    }
                    else
                    {
                        Instantiate(RightB, hit.point + new Vector3(.5f,.015f,0), Quaternion.Euler(90,0,0));
                        foot *= -1;
                    }
                }
               
            }
            yield return new WaitForSeconds(.25f);
        }
        yield return 0;
    }*/
}