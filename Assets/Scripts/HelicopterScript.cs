using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterScript : MonoBehaviour
{
    public float speed = 6f;
    bool activeTrigger;
    void Update()
    {
        if (activeTrigger == true)
        {
            transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = gameObject.transform;
            col.gameObject.GetComponent<PlayerControlScript>().enabled = false;
            StartCoroutine(HelicopterMoveCheck());
        }
    }
    IEnumerator HelicopterMoveCheck()
    {
        activeTrigger = false;
        yield return new WaitForSeconds(3.0f);
        activeTrigger = true;
    }
}
