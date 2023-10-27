using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Adjust the speed as needed.
    // public LevelGenerator levelGenerator;
    public AudioSource movementAudioSource;
    // public AudioSource eatingPelletAudioSource;
    // public ParticleSystem dustParticleEffect;

    private Vector3 targetPosition;
    private Vector3 startPosition;
    private float journeyLength;
    private float startTime;
    private bool isMoving = false;
    private Vector3 lastInputDirection;
    private Vector3 currentInputDirection;

    private void Start()
    {
        // Initialize PacStudent's position to the starting point (e.g., where you want to start on the grid).
        transform.position = GetPacStudentStartingPosition();
        targetPosition = transform.position;
    }

    private void Update()
    {
        Vector3 inputDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputDirection = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputDirection = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputDirection = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputDirection = Vector3.right;
        }

        // Store the last input direction if there's valid input.
        if (inputDirection != Vector3.zero)
        {
            lastInputDirection = inputDirection;
        }

        if (isMoving)
        {
            // Play the movement audio clip.
            if (!movementAudioSource.isPlaying)
            {
                movementAudioSource.Play();
            }

            // // Start the dust particle effect when PacStudent is moving.
            // if (!dustParticleEffect.isPlaying)
            // {
            //     dustParticleEffect.Play();
            // }

            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float journeyFraction = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, journeyFraction);

            if (journeyFraction >= 1.0f)
            {
                isMoving = false;
                transform.position = targetPosition;
            }
        }
        else
        {
            // Stop the movement audio clip.
            movementAudioSource.Stop();

            // Stop the dust particle effect when PacStudent is not moving.
            // dustParticleEffect.Stop();

            // If PacStudent is not moving, handle input.
            TryMove(lastInputDirection);
        }
    }

    private void TryMove(Vector3 direction)
    {
        Vector3 nextPosition = transform.position + direction;

        if (IsNextPositionValid(nextPosition))
        {
            currentInputDirection = direction;
            targetPosition = nextPosition;
            startPosition = transform.position;
            journeyLength = Vector3.Distance(startPosition, targetPosition);
            startTime = Time.time;
            isMoving = true;
        }
        else if (IsNextPositionValid(transform.position + currentInputDirection))
        {
            // If the last input direction isn't valid, check if the current input direction is valid.
            targetPosition = transform.position + currentInputDirection;
            startPosition = transform.position;
            journeyLength = Vector3.Distance(startPosition, targetPosition);
            startTime = Time.time;
            isMoving = true;
        }
        else
        {
            // If neither the last input direction nor the current input direction are valid, do nothing (PacStudent stops moving).
        }
    }

    private bool IsNextPositionValid(Vector3 position)
    {
        // Implement your logic to check if the next position is valid.
        // You can use the LevelGenerator script to check the level map.
        // For example, you can check if the next position is a pellet or empty space.

        // You can call a function in the LevelGenerator script to check the validity, like this:
        // bool isValid = levelGenerator.IsPositionValid(position);

        // Return true or false based on your validation logic.
        // Replace this with your own validation logic.
        return true;
    }

    private Vector3 GetPacStudentStartingPosition()
    {
        // Set PacStudent's starting position.
        return new Vector3(-12.47f, 13.45f, 0f);
    }
}
