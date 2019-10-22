using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlockCollision : MonoBehaviour
{
    public GameObject moveTileBlock;
    public GameObject player;
    private Rigidbody rb;
    
    public float xForce;
    public float yForce;
    public float zForce;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
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
            rb.AddForce(new Vector3(xForce,yForce,zForce), ForceMode.Impulse);
        }
    }
}
