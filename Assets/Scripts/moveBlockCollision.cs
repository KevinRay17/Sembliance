using UnityEngine;

public class moveBlockCollision : MonoBehaviour
{
    private GameObject moveTileBlock;
    private GameObject oppositeTileBlock;
    private GameObject player;
    private Rigidbody rb;

   // public Vector3 startPos;
    public float xForce;
    public float yForce;
    public float zForce;
    
    private Collider collider;
    private Collider collider2;

    public bool onMe;

    public float xDir;
    public float yDir;
    public float zDir;
    public bool moveTile = false;
    public bool moveOneTile;

    int layerMask = 1 << 10;
    // Start is called before the first frame update
    void Start()
    {
        moveTileBlock = this.gameObject.transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity,
                layerMask))
        {
            if (hit.transform.CompareTag("MoveTile") || hit.transform.CompareTag("MoveTileBlack")){
                oppositeTileBlock = hit.transform.parent.gameObject;
            }
        }
            //        startPos = moveTileBlock.GetComponent<Transform>();
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
                onMe = false;
            }
        }
        if (moveTile == true)
        {
            moveTileBlock.transform.position += new Vector3(xDir, yDir, zDir) * 0.1f * Time.deltaTime;
            if (oppositeTileBlock != null)
                oppositeTileBlock.transform.position += new Vector3(xDir, yDir, zDir) * 0.1f * Time.deltaTime;
            player.transform.position += new Vector3(xDir, yDir, zDir) * 0.1f * Time.deltaTime;
        }

        if (moveOneTile == true)
        {
            moveTileBlock.transform.position += new Vector3(xDir, yDir, zDir) * 0.1f * Time.deltaTime;
            if (oppositeTileBlock != null)
                oppositeTileBlock.transform.position += new Vector3(xDir, yDir, zDir) * 0.1f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag.Equals("StopMove"))
        {
            Debug.Log("collided");
            
            if (onMe)
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


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            moveTile = true;
            onMe = true;
            Debug.Log("enter");
        }
        if (other.gameObject.tag.Equals("StopMove"))
        {
            moveTile = false;
        }
    }
   
   

}
