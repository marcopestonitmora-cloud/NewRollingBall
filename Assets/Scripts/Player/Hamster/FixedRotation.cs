using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    [SerializeField] private Transform ball;  // reference to the ball
    [SerializeField] private float rotationSpeed = 10f; // smooth rotation speed

    private Vector3 lastBallPosition;

    void Start()
    {
        lastBallPosition = ball.position;
    }

    void LateUpdate()
    {
        //Keep Position
        transform.position = ball.position;

        // calculate ball movement direction
        Vector3 moveDirection = ball.position - lastBallPosition;
        moveDirection.y = 0f; 
        
        if (moveDirection.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Update to the new position
        lastBallPosition = ball.position;
    }
}
