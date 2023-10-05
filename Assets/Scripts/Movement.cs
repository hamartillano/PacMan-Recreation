using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Transform[] transformArray;
    private int moveCounter = 0;
    private Vector3[] movePositions = new Vector3[4];
    private float moveSpeed = 1.0f; // Adjust this value to control the movement speed
    private float moveTimer = 0.0f;
    private float delayBeforeMovement = 4f; // Time delay before starting movement

    private bool isMoving = false;

    void Start()
    {
        movePositions[0] = new Vector3(-12.47f, 13.45f, 0f);
        movePositions[1] = new Vector3(-7.5f, 13.45f, 0f);
        movePositions[2] = new Vector3(-7.5f, 9.68f, 0f);
        movePositions[3] = new Vector3(-12.47f, 9.68f, 0f);

        transformArray[0].position = movePositions[0];

        // Start the timer for the initial delay
        StartCoroutine(StartMovementDelay());
    }

    void Update()
    {
        if (isMoving)
        {
            MoveObjects();
        }
    }

    private IEnumerator StartMovementDelay()
    {
        yield return new WaitForSeconds(delayBeforeMovement);
        isMoving = true;
    }

    private void MoveObjects()
    {
        // Get the current positions of the objects.
        Vector3 redPosition = transformArray[0].position;

        // Calculate the position differences.
        Vector3 targetPosition = movePositions[moveCounter];
        Vector3 redDelta = targetPosition - redPosition;

        // Check if we need to move Pac-Man
        if (moveTimer < 1.0f)
        {
            // Update the timer based on deltaTime
            moveTimer += Time.deltaTime * moveSpeed;

            // Interpolate Pac-Man's position
            transformArray[0].position = redPosition + redDelta * moveTimer;
        }
        else
        {
            // Reset the timer and move to the next position
            moveTimer = 0.0f;
            moveCounter = (moveCounter + 1) % 4;
        }
    }
}
