using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    float gravity = -14f;
    public float verticalSpeed = 0f;
    float forwardSpeed = 4f;
    float forwardAcceleration = 0.1f;
    float jumpForce = 10f;
    [SerializeField] Transform spriteTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (verticalSpeed>-20f)
        {
            if(verticalSpeed>0f)
            {
                verticalSpeed += gravity * Time.deltaTime * 2f; // Speed up the fall when going up
            }
            else{
                verticalSpeed += gravity * Time.deltaTime; // Normal fall speed
            }
        }
        if(forwardSpeed<10f)
        {
            forwardSpeed += forwardAcceleration * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalSpeed = jumpForce;
        }
        transform.Translate(new Vector2(forwardSpeed,0) * Time.deltaTime);
        transform.Translate(new Vector2(0,verticalSpeed) * Time.deltaTime);
        setBirdDirection();
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

    void setBirdDirection()
    {
        Vector2 direction = new Vector2(forwardSpeed, verticalSpeed);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spriteTransform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
