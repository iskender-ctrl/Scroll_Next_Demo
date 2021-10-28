using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
    public GameObject player;

    float dampTime = 0.1f;
    Vector3 positionVelocity = Vector3.zero;
    private Vector3 offset;
    public bool follow = true;
    public bool finalFollow = false;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (follow == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref positionVelocity, dampTime);
        }
        if (finalFollow == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(2.6f, 4.5f, 29.09f), Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(10.16f, 0, 0), Time.deltaTime * dampTime);
        }
    }
}
