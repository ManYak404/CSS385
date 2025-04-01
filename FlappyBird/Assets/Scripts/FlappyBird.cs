using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    float gravity = -7f;
    public float verticalSpeed = 0f;
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
        if (verticalSpeed>-20f)
        {
            verticalSpeed += gravity * Time.deltaTime;
        }
        if(forwardSpeed<10f)
        {
            forwardSpeed += forwardAcceleration * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalSpeed = jumpForce;
        }
        transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Flappy bird hit a trigger!");
        if (other.CompareTag("Pipe"))
        {
            Debug.Log("Flappy bird hit a pipe!");
            SceneManager.LoadScene("GameOverScene");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Flappy bird hit the ground!");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
