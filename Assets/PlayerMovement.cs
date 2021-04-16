using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveForce = 10f;
    public float jumpForce = 10f;
    private Rigidbody body;


    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Movement by transform is instantaneous and not animated
            // And doesn't benefit from physics until the after the transform is complete
            //transform.position += new Vector3(0f, 2f, 0f) * Time.deltaTime * moveForce;

            // If using a Rigidbody for physics, prefer "adding force" to it
            body.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            body.AddForce(new Vector3(moveForce, 0f, 0f), ForceMode.Impulse);
            //transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * moveForce;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            body.AddForce(new Vector3(-moveForce, 0f, 0f), ForceMode.Impulse);
            //transform.position -= new Vector3(1f, 0f, 0f) * Time.deltaTime * moveForce;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            body.AddForce(new Vector3(0f, 0f, moveForce), ForceMode.Impulse);
            //transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * moveForce;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            body.AddForce(new Vector3(0f, 0f, -moveForce), ForceMode.Impulse);
            //transform.position -= new Vector3(0f, 0f, 1f) * Time.deltaTime * moveForce;
        }
    }
}
