using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    public float speed = 3;
    float dragSpeed = 0.005f;
    Animator anim;
    public GameObject helicopter;
    bool IsEnabled = true;
    bool finishLine = false;
    bool finishJumpLine = false;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3F;
    public Transform finishJump;
    public GameObject winPanel, losePanel;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnabled)
        {
            ControllPlayer();
        }
        if (finishLine == true)
        {
            FinishLineMove();
        }
        if (finishJumpLine == true)
        {
            FinishJumpMove();
        }
        if (transform.position.y < -1.5f)
        {
            InvokeRepeating("UILosePanel", 1, 1);
        }
    }


    void ControllPlayer()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * dragSpeed * Time.deltaTime,
                    transform.position.y,
                    transform.position.z);
                transform.Rotate(transform.up, Vector3.Dot(touch.deltaPosition, Camera.main.transform.right), Space.World);
            }
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Cubes")
        {
            col.rigidbody.useGravity = true;
            col.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            InvokeRepeating("UILosePanel", 1, 1);
            anim.SetBool("Fall", true);
            IsEnabled = false;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "FinishLine")
        {
            IsEnabled = false;
            finishLine = true;
            Camera.main.GetComponent<CameraControlScript>().follow = false;
            Camera.main.GetComponent<CameraControlScript>().finalFollow = true;

        }
        if (col.gameObject.tag == "Jump")
        {
            finishLine = false;
            finishJumpLine = true;
            InvokeRepeating("WinPanel", 1, 1);
        }

    }
    void FinishLineMove()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(2f, transform.position.y, 50.86334f), ref velocity, smoothTime);
    }
    void FinishJumpMove()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(2.191f, 2.881f, 52.586f), ref velocity, smoothTime);
        Quaternion target = Quaternion.Euler(0, 180, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, speed * Time.deltaTime);
        anim.SetBool("Bye", true);
    }
    void WinPanel()
    {
        winPanel.SetActive(true);
    }
    void UILosePanel()
    {
        losePanel.SetActive(true);
    }
}
