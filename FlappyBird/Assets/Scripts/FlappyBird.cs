using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    float gravity = -7f;
    float verticalSpeed = 0f;
    float forwardSpeed = 4f;
    float forwardAcceleration = 0.1f;
    float jumpForce = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed += gravity * Time.deltaTime;
        forwardSpeed += forwardAcceleration * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalSpeed = jumpForce;
        }
        transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
    }
}
