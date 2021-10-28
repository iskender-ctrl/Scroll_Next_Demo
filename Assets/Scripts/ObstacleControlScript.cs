using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControlScript : MonoBehaviour
{
    public float turnSpeed = 5f;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime, Space.World);
        gameObject.GetComponentInChildren<Rigidbody>().AddForce(Vector3.up);
    }
}
