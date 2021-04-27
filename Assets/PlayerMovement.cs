using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveForce = 0.1f;
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
        if (Input.GetKey(KeyCode.Space))
        {
            // Movement by transform is instantaneous and not animated
            // And doesn't benefit from physics until the after the transform is complete
            //transform.position += new Vector3(0f, 2f, 0f) * Time.deltaTime * moveForce;

            // If using a Rigidbody for physics, prefer "adding force" to it
            body.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //body.AddForce(new Vector3(moveForce, 0f, 0f), ForceMode.Impulse);
            //transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * moveForce;

            Vector3 v = transform.right * moveForce;
            body.velocity = v;  // Sets velocity to left movement
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * moveForce, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //body.AddForce(new Vector3(-moveForce, 0f, 0f), ForceMode.Impulse);
            //transform.position -= new Vector3(1f, 0f, 0f) * Time.deltaTime * moveForce;

            Vector3 v = -transform.right * moveForce;  // -transform.right = left
            body.velocity = v;  // Sets velocity to left movement
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * moveForce, Space.World);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //body.AddForce(new Vector3(0f, 0f, moveForce), ForceMode.Impulse);
            //transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * moveForce;

            Vector3 v = transform.forward * moveForce;  // -transform.up = up
            body.velocity = v;  // Sets velocity to left movement
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //body.AddForce(new Vector3(0f, 0f, -moveForce), ForceMode.Impulse);
            //transform.position -= new Vector3(0f, 0f, 1f) * Time.deltaTime * moveForce;
            Vector3 v = -transform.forward * moveForce;  // -transform.right = left
            body.velocity = v;  // Sets velocity to left movement
        }
    }
}
