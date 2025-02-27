using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning_Sword : MonoBehaviour
{

    // Start is called before the first frame update

    public Transform target;
    public float orbitDistance = 1.5f;
    public float orbitDegreesPerSec = 90.0f;
    public Vector3 relativeDistance = Vector3.zero;
    public bool once = true;
    // Use this for initialization
    void Start()
    {


        target = GameObject.FindWithTag("Player").transform;
        relativeDistance = transform.position - target.position;

    }

    void Orbit()
    {

        // Keep us at the last known relative position
        transform.position = (target.position + relativeDistance);
        transform.RotateAround(target.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
        // Reset relative position after rotate
        if (once)
        {
            transform.position *= orbitDistance;
            once = false;
        }
        relativeDistance = transform.position - target.position;

    }

    void FixedUpdate()
    {

        Orbit();

    }
}

