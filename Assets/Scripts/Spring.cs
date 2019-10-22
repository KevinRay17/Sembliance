using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public bool switcher;
    public float descendSpeed = -0.2f;
    public float ascendSpeed = 0.5f;
    public float springMovement;

    public float forceMultiplier = 30f;

    public GameObject player;

    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f) //Reaches min, starts ascent
        {
            switcher = false;
        }
        else if (transform.position.y > -5f) //Reaches max, starts descent
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

        transform.position += new Vector3(0f, springMovement, 0f);

        if (transform.position.y > -5f && !switcher)
        {
            if (player != null)
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
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
        player = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        player = null;
    }
}
