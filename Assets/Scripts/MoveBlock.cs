using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public float xDir;
    public float yDir;
    public float zDir;
    public bool moveTile = false;
    public GameObject moveTileBlock;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveTile = false;
        }
        if (moveTile == true)
        {
            moveTileBlock.transform.position += new Vector3(xDir,yDir,zDir) * 0.1f;
            player.transform.position += new Vector3(xDir,yDir,zDir) * 0.1f;
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
