using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlockCollision : MonoBehaviour
{
    public GameObject moveTileBlock;
    public GameObject player;
    private Rigidbody rb;

   // public Vector3 startPos;
    public float xForce;
    public float yForce;
    public float zForce;
    
   
    
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();

//        startPos = moveTileBlock.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("StopMove"))
        {
            Destroy(moveTileBlock);
            Destroy(other.gameObject);
            if (player.GetComponent<Controller>().onMove)
            {
                rb.AddForce(new Vector3(xForce,yForce,zForce), ForceMode.Impulse);
            }
        }
    }
}
