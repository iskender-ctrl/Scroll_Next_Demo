using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 pos1;
    private Vector3 pos2;
    void Start()
    {
        pos1 = new Vector3(0.61f, transform.position.y, transform.position.z);
        pos2 = new Vector3(3.986f, transform.position.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
