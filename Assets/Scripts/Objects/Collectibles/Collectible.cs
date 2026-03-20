using UnityEngine;

public abstract class Collectible : MonoBehaviour, ICollectible
{
    public abstract void ItemCollected(GameObject player);
    
    //VERTICAL MOVEMENT
    private Vector3 starPosition;
    private int verticalDirection = 1;
    public float speed { get; private set; } = 1f;
    public float rotationSpeed { get; private set; } = 100f;
    private float timer = 0f;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMain>() != null)
        {
            ItemCollected(other.gameObject);
        }
    }

    protected virtual void Start()
    {
        starPosition = transform.position;
    }

    protected virtual void Update()
    {
        HoverMovement();
        HoverRotation();
    }

    protected virtual void HoverMovement()
    {
        timer += Time.deltaTime;

        transform.position += Vector3.up * (verticalDirection * Time.deltaTime * speed);
        
        if (timer >= 0.9f)
        {
            verticalDirection *= -1;
            timer = 0f;
        }
    }

    protected virtual void HoverRotation()
    {
        transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
