using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    float minHeight;
    float maxHeight;

    [Header("as a child of the (Parent) City Object.")]
    [Header("3. Add either the White or Black Spring tile prefabs")]
    [Header ("2. Add a BoxCollider to the City Block (Child) Object.")]
    [Header("1. Drag this script onto a City (Parent) Object.")]

    public bool switcher;
    public float descendSpeed = -0.05f;
    public float ascendSpeed = 0.2f;
    public float springMovement;

    public float forceMultiplier = 10f;

    public GameObject player;

    public ParticleSystem particles;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();

        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;

        if (gameObject.tag == "CityWhite")
        {
            minHeight = -10;
            maxHeight = -5;
        }
        else if (gameObject.tag == "CityBlack")
        {
            minHeight = 5;
            maxHeight = 0;

            descendSpeed *= -1;
            ascendSpeed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "CityWhite")
        {
            WhiteCityBlock();
        }
        else if (gameObject.tag == "CityBlack")
        {
            BlackCityBlock();
        }
    }

    void WhiteCityBlock()
    {
        if (transform.localPosition.y < minHeight) //Reaches min, starts ascent
        {
            switcher = false;
        }
        else if (transform.localPosition.y > maxHeight) //Reaches max, starts descent
        {
            switcher = true;
        }
        if (switcher)
        {
            springMovement = descendSpeed;
        }
        else
        {
            springMovement = ascendSpeed;
        }

        transform.localPosition += new Vector3(0f, springMovement, 0f);

        if (transform.localPosition.y > maxHeight && !switcher)
        {
            if (player != null)
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
                StartCoroutine(coyoteTime());
            }
            particles.Emit(100);
        }
    }

    void BlackCityBlock()
    {
        if (transform.localPosition.y > minHeight) //Reaches min, starts ascent
        {
            switcher = true;
        }
        else if (transform.localPosition.y < maxHeight) //Reaches max, starts descent
        {
            switcher = false;
        }
        if (switcher)
        {
            springMovement = ascendSpeed;
        }
        else
        {
            springMovement = descendSpeed;
        }

        transform.localPosition += new Vector3(0f, springMovement, 0f);

        if (transform.localPosition.y < maxHeight && !switcher)
        {
            if (player != null)
            {
                player.GetComponent<Rigidbody>().AddForce(-Vector3.up * forceMultiplier/2, ForceMode.Impulse);
                StartCoroutine(coyoteTime());
            }
            particles.Emit(100);
        }
    }

    IEnumerator coyoteTime()
    {
        yield return new WaitForSeconds(0.1f);
        Controller.instance.grounded = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = null;
        }
    }
}
