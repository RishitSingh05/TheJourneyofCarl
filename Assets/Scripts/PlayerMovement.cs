using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 7f;       // Initial forward speed
    public float horizontalSpeed = 8f;  // Horizontal movement speed
    public float rightLimit = 5.5f;     // Right movement boundary
    public float leftLimit = -5.5f;     // Left movement boundary
    private float timeElapsed = 0f;     // Timer to track time since the last speed increase
    public float speedIncreaseInterval = 20f; // Time interval for speed increase

    void Update()
    {
        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        // Increase the timer
        timeElapsed += Time.deltaTime;

        // Check if the interval has passed to increase speed
        if (timeElapsed >= speedIncreaseInterval)
        {
            playerSpeed *= 1.25f; // Double the speed
            timeElapsed = 0f;  // Reset the timer
        }

        // Check for left movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }

        // Check for right movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }
        }
    }
}
