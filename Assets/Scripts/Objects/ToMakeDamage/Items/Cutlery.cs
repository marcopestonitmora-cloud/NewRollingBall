using UnityEngine;

public class Cutlery: MakeDamage
{
    private PlayerInteractionSystem gotHit;
    [SerializeField]private LivesManager livesManager;
    [SerializeField] private PlayerDamageSystem damageVisual;
    
    [Header("Sounds")]
    [SerializeField]private AudioClip hitSound;
    [SerializeField]private float hitSoundVolume = 10f;

    public override void TakeDamage(GameObject player)
    {
        gotHit = player.GetComponent<PlayerInteractionSystem>();
        if (gotHit != null)
        {
            AudioManager.instance.PlaySound(hitSound,hitSoundVolume);
            damageVisual.FlashDamage();
            livesManager.LoseLives();
        }
    }
}
