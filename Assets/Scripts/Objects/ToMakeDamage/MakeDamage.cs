using UnityEngine;

public abstract class MakeDamage : MonoBehaviour, IDamageable
{
    public abstract void TakeDamage(GameObject player);
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMain>() != null)
        {
            TakeDamage(other.gameObject);
        }
    }
}
