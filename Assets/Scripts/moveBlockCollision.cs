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
   
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();

//        startPos = moveTileBlock.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("StopMove") || other.gameObject.tag.Equals("StopMove2") )
        {
            if (player.GetComponent<Controller>().onMove)
            {
                rb.AddForce(new Vector3(xForce,yForce,zForce), ForceMode.Impulse);
                player.GetComponent<Controller>().onMove = false;
            }
            else if (player.GetComponent<Controller>().onMoveBlack)
            {
                rb.AddForce(new Vector3(xForce,-yForce,zForce), ForceMode.Impulse);
                player.GetComponent<Controller>().onMoveBlack = false;
            }
            Destroy(moveTileBlock);
            Destroy(oppositeTileBlock);
            Destroy(other.gameObject);
        }
    }
}
