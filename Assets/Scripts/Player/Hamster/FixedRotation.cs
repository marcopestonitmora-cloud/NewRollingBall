using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    [SerializeField] private Transform HamsterPosition;  // reference to the empty
    [SerializeField] private Vector3 offset = new Vector3(0, -0.2f, 0);
    [SerializeField] private float rotationSpeed = 10f; // smooth rotation speed

    private Vector3 lastBallPosition;

    void Start()
    {
        lastBallPosition = HamsterPosition.position;
    }

    void Update()
    {
        //Keep Position
        transform.position = HamsterPosition.position + offset;

        // calculate ball movement direction
        Vector3 moveDirection = HamsterPosition.position - lastBallPosition;
        moveDirection.y = 0f; 
        
        if (moveDirection.sqrMagnitude > 0.0001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            targetRotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Update to the new position
        lastBallPosition = HamsterPosition.position;
    }
}
