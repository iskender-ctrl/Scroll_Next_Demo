using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConrolScript : MonoBehaviour
{
    public float speed = 5;
    Animator anim;
    public GameObject player;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 1.873638f)
        {
            Destroy(gameObject);
        }
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("Jump", true);
            gameObject.GetComponent<EnemyConrolScript>().enabled = false;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Turn")
        {
            gameObject.transform.eulerAngles = new Vector3(
            gameObject.transform.eulerAngles.x,
            gameObject.transform.eulerAngles.y + -127,
            gameObject.transform.eulerAngles.z);
        }
    }
}
