using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlockCollision : MonoBehaviour
{
    public GameObject moveTileBlock;
    public GameObject oppositeTileBlock;
    private GameObject player;
    private Rigidbody rb;

   // public Vector3 startPos;
    public float xForce;
    public float yForce;
    public float zForce;
    
    private Collider collider;
    private Collider collider2;

    private bool onMe;
   
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody>();

//        startPos = moveTileBlock.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag.Equals("StopMove"))
        {
            Debug.Log("collided");
            if (player.GetComponent<Controller>().onMove && onMe)
            {
                Debug.Log("upHere");
                rb.AddForce(new Vector3(xForce,yForce,zForce), ForceMode.Impulse);
                Debug.Log("middleHere");
                player.GetComponent<Controller>().onMove = false;
                Debug.Log("here");
            }
            else if (player.GetComponent<Controller>().onMoveBlack && onMe)
            {
                rb.AddForce(new Vector3(xForce,-yForce,zForce), ForceMode.Impulse);
                player.GetComponent<Controller>().onMoveBlack = false;
            }
           if (oppositeTileBlock != null)
            Destroy(oppositeTileBlock);
            Destroy(other.gameObject);
            Destroy(moveTileBlock);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("col");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player col");
            onMe = true;
        } 
    }
    private void OnCollisionExit(Collision other)
    {
        Debug.Log("leave");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("leave play");
            onMe = false;
        }
    }
}
