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
    public float speedTile;

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
        
        //Get Inputs and move using Translation
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
        //if (CitySwap.OnWhite)
        transform.Translate(strafe, 0, translation);
        
      
        //Jump Force in opposite of ground, Start Timer to prevent cast detection after jump
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
        
        //Raycast for gravity tile for infinity downwards. double and undouble gravity
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
        //If distance from ground is more than ten start game
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


        //Raycast for speed tile, reset immediately if not hitting speedtile
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (transform.localScale.y + .1f)) && hit.transform.gameObject.CompareTag("SpeedTile"))
        {
            speed = 15;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (transform.localScale.y + .1f)) && !hit.transform.gameObject.CompareTag("SpeedTile"))
        {
            speed = 5;
        }
        //Raycast and check if you're already grounded and wait for jumpWait to prevent double jumping. Start placing decals
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (transform.localScale.y + .1f), layerMask) && jumpWaited && !grounded)
        {
            StartCoroutine(PlaceFeet());
            grounded = true;
        }
        //Unlock Cursor
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }

    //Short wait to prevent raycast from double grounding
    IEnumerator JumpWait()
    {
     yield return new WaitForSeconds(.25f);
        jumpWaited = true;
    }

    //if you fall you die. Will change to coroutine with effects and sounds
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
           Restart();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("StopMove"))
        {
            grounded = false;
        }
        if (grounded)
        {
            
            //If you are on the ground and the city above you collides with you. Die
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

    //Reset Statics
    void Restart()
    {
        CitySwap.OnWhite = true;
        if (Physics.gravity.y > 0)
        {
            Physics.gravity = new Vector3(0,Physics.gravity.y * -1,0);
        }
        SceneManager.LoadScene(0);
    }

    //Check ground for which foot type to place and continue placing while grounded
    IEnumerator PlaceFeet()
    {
        int foot = 1;
        yield return 0;
        while (grounded)
        {
            
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit,
                (Mathf.Infinity), layerMask))
            {
                if (CitySwap.OnWhite)
                {
                    if (foot == 1)
                    {
                        GameObject leftW =Instantiate(LeftW, hit.point - new Vector3(.5f, .1f, 0), new Quaternion(0,0,0,180));
                        leftW.transform.forward = hit.normal * -1;
                        leftW.transform.parent = hit.transform.gameObject.transform;
                        foot *= -1;
                    }
                    else
                    {
                       GameObject rightW = Instantiate(RightW, hit.point + new Vector3(.5f,-.1f,0),new Quaternion(0,0,0,180));
                        rightW.transform.forward = hit.normal * -1;
                        rightW.transform.parent = hit.transform.gameObject.transform;
                        foot *= -1;
                    }
                }
                else
                {
                    if (foot == 1)
                    {
                        GameObject leftB = Instantiate(LeftB, hit.point - new Vector3(.5f, -.1f, 0), Quaternion.identity);
                        leftB.transform.forward = hit.normal * -1;
                        leftB.transform.parent = hit.transform.gameObject.transform;
                        foot *= -1;
                    }
                    else
                    {
                        GameObject rightB = Instantiate(RightB, hit.point + new Vector3(.5f,.1f,0), Quaternion.identity);
                        rightB.transform.forward = hit.normal * -1;
                        rightB.transform.parent = hit.transform.gameObject.transform;
                        foot *= -1;
                    }
                }
               
            }
            //Wait this long until next foot placed. Need change to distance travelled
            yield return new WaitForSeconds(.25f);
        }
        yield return 0;
    }
}