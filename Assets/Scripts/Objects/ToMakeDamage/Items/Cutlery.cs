using UnityEngine;

public class Cutlery: MakeDamage
{
    private PlayerInteractionSystem gotHit;
    [SerializeField]private LivesManager livesManager;

    public override void TakeDamage(GameObject player)
    {
        gotHit = player.GetComponent<PlayerInteractionSystem>();
        if (gotHit != null)
        {
            livesManager.LoseLives();
        }
    }
}
