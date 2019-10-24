using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public float xDir;
    public float yDir;
    public float zDir;
    public bool moveTile = false;
    public bool moveOneTile;
    public GameObject moveTileBlock;
    public GameObject oppositeTileBlock;
    private GameObject player;

    private Collider collider;
    private Collider collider2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (moveTile == true)
            {
                moveTile = false;
                moveOneTile = true;
            }
        }
        if (moveTile == true)
        {
            moveTileBlock.transform.position += new Vector3(xDir,yDir,zDir) * 0.1f * Time.deltaTime;
            if (oppositeTileBlock != null)
            {
                oppositeTileBlock.transform.position += new Vector3(xDir,yDir,zDir) * 0.1f * Time.deltaTime;
            }
            player.transform.position += new Vector3(xDir,yDir,zDir) * 0.1f * Time.deltaTime;
        }

        if (moveOneTile == true)
        {
            if (oppositeTileBlock != null)
            {
                oppositeTileBlock.transform.position += new Vector3(xDir,yDir,zDir) * 0.1f * Time.deltaTime;
            }
            moveTileBlock.transform.position += new Vector3(xDir,yDir,zDir) * 0.1f * Time.deltaTime;
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            moveTile = true;
        }
        if (other.gameObject.tag.Equals("StopMove"))
        {
            moveTile = false;
        }
    }
}
